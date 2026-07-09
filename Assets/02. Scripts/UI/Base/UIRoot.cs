using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.UI.Base
{
    public class UIRoot : MonoBehaviour
    {
        private void Start()
        {
            RegisterAllUI();
        }

        private void RegisterAllUI()
        {
            BaseUI[] uis =
                GetComponentsInChildren<BaseUI>(true);

            foreach (BaseUI ui in uis)
            {
                if (ui is SceneUI sceneUI)
                {
                    GameManager.Instance.UI.Register(sceneUI);
                }
                else if (ui is PopupUI popupUI)
                {
                    GameManager.Instance.UI.Register(popupUI);
                }
            }
        }
    }
}