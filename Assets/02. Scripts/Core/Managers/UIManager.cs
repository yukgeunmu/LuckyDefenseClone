
using Cysharp.Threading.Tasks;
using LuckyDefense.UI.Base;
using System;
using System.Collections.Generic;


namespace LuckyDefense.Core.Manager
{
    public class UIManager
    {
        private readonly Dictionary<Type, BaseUI> sceneUIs = new();

        private readonly Stack<PopupUI> popupStack = new();


        public void Initialize()
        {

        }

        public void Register(BaseUI ui)
        {
            sceneUIs[ui.GetType()] = ui;
        }

        public T Get<T>() where T : BaseUI
        {
            return sceneUIs[typeof(T)] as T;
        }

        //public async UniTask<T> Open<T>()
        //{

        //}


        public void Close(PopupUI popup)
        {
            popupStack.Pop();

            UnityEngine.Object.Destroy(popup.gameObject);
        }
    }
}