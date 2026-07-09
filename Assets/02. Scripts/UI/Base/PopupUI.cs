
using LuckyDefense.Core.Manager;

namespace LuckyDefense.UI.Base
{
    public abstract class PopupUI : BaseUI
    {
        public virtual void Close()
        {
            GameManager.Instance.UI.Close(this);
        }
    }
}