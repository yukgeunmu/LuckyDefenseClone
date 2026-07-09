
using UnityEngine;

namespace LuckyDefense.UI.Base
{
    public abstract class BaseUI : MonoBehaviour
    {
        public virtual void Initialize() { }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}