
using LuckyDefense.Core.Manager;
using Unity.VisualScripting;

namespace LuckyDefense.UI.Base
{
    public abstract class PopupUI : BaseUI
    {
        public virtual void Close()
        {

            GameManager.Instance.UI.Close(GetType());
        }
    }
}