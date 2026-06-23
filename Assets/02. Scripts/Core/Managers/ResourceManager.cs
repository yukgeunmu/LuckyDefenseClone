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

        public bool SpendSilver(int amount)
        {
            if (Silver < amount)
                return false;

            Silver -= amount;

            EventBus.Publish(
                new SilverChangedEvent(Silver));

            return true;
        }
    }
}

