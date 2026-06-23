namespace LuckyDefense.Core
{
    public class ResourceManager
    {
        public int Silver { get; private set; }

        public void AddSilver(int amount)
        {
            Silver += amount;

            EventBus.Publish(new SilverChangedEvent(Silver));
        }
    }
}

