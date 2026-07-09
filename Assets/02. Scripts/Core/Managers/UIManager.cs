using Cysharp.Threading.Tasks;
using LuckyDefense.UI.Base;
using System;
using System.Collections.Generic;


namespace LuckyDefense.Core.Manager
{
    public class UIManager
    {
        private readonly Dictionary<Type, SceneUI> sceneUIs = new();

        private readonly Dictionary<Type, PopupUI> popupUIs = new();

        private readonly Stack<PopupUI> popupStack = new();

        public bool HasPopup => popupStack.Count > 0;

        #region SceneUI

        public void Register(SceneUI ui)
        {
            sceneUIs[ui.GetType()] = ui;

            ui.Initialize();
        }

        #endregion


        #region Popup

        public void Register(PopupUI popup)
        {
            popupUIs[popup.GetType()] = popup;

            popup.Initialize();

            popup.Hide();
        }


        public T Open<T>() where T : PopupUI
        {
            T popup = Get<T>();

            if (popup == null)
                return null;

            popup.Show();

            popupStack.Push(popup);

            return popup;
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