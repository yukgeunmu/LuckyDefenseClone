using LuckyDefense.Core.Events;

namespace LuckyDefense.Core.Manager
{
    public class ResourceManager
    {
        public int Gold { get; private set; }

        public void AddGold(int amount)
        {
            Gold += amount;

            EventBus.Publish(new GoldChangedEvent(Gold));
        }

        public bool SpendGold(int amount)
        {
            if (Gold < amount)
                return false;

            Gold -= amount;

            EventBus.Publish(new GoldChangedEvent(Gold));

            return true;
        }
    }
}

