using Cysharp.Threading.Tasks;
using LuckyDefense.UI.Base;
using LuckyDefense.UI.Data;
using LuckyDefense.UI.Popup;
using LuckyDefense.UI.Recipe;
using LuckyDefense.UI.Scene;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace LuckyDefense.Core.Manager
{
    public class UIManager
    {
        private readonly Dictionary<Type, SceneUI> sceneUIs = new();

        private readonly Dictionary<Type, PopupUI> popupUIs = new();

        private readonly Stack<PopupUI> popupStack = new();

        private CanvasRoot canvasRoot;

        public bool HasPopup => popupStack.Count > 0;

        public void Initialize( CanvasRoot canvasRoot)
        {
            this.canvasRoot = canvasRoot;
        }

        private async UniTask<T> CreateUI<T>(Transform parent) where T : BaseUI
        {

            AssetReferenceGameObject prefab =
                GameManager.Instance.Data.GetUIAsset<T>();

            GameObject uiPrefab =
                await GameManager.Instance.Resource
                    .LoadAsync<GameObject>(prefab);

            GameObject instance =
                UnityEngine.Object.Instantiate(
                    uiPrefab,
                    parent,
                    false);

            return instance.GetComponent<T>();
        }

        public async UniTask<T> ShowScene<T>()  where T : SceneUI
        {
            if (sceneUIs.TryGetValue(typeof(T), out SceneUI ui))
            {
                ui.Show();

                return ui as T;
            }

            T scene = await CreateUI<T>(canvasRoot.SceneRoot);

            Register(scene);

            scene.Show();

            return scene;
        }

        public async UniTask<T> Open<T>() where T : PopupUI
        {
            if (!popupUIs.TryGetValue(typeof(T), out PopupUI popup))
            {
                T newPopup = await CreateUI<T>(canvasRoot.PopupRoot);

                Register(newPopup);

                popup = newPopup;
            }

            popup.Show();

            popupStack.Push(popup);

            return popup as T;
        }


        #region SceneUI

        private void Register(SceneUI ui)
        {
            sceneUIs[ui.GetType()] = ui;

            ui.Initialize();
        }

        #endregion


        #region Popup

        private void Register(PopupUI popup)
        {
            popupUIs[popup.GetType()] = popup;

            popup.Initialize();

            popup.Hide();
        }


        public void Close<T>() where T : PopupUI
        {
            T popup = Get<T>();

            if (popup == null)
                return;

            popup.Hide();

            if (popupStack.Count > 0 &&
                popupStack.Peek() == popup)
            {
                popupStack.Pop();
            }
        }

        public void Close(Type type)
        {
            if (!popupUIs.TryGetValue(type, out PopupUI popup))
                return;

            popup.Hide();

            if (popupStack.Count > 0 &&
                popupStack.Peek() == popup)
            {
                popupStack.Pop();
            }
        }



        public void CloseAll()
        {
            while (popupStack.Count > 0)
            {
                PopupUI popup = popupStack.Pop();

                popup.Hide();
            }
        }

        #endregion


        public T Get<T>() where T : BaseUI
        {
            Type type = typeof(T);

            if (sceneUIs.TryGetValue(type, out SceneUI scene))
                return scene as T;

            if (popupUIs.TryGetValue(type, out PopupUI popup))
                return popup as T;


            return null;
        }


    }
}