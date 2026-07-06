using LuckyDefense.Core.Events;


namespace LuckyDefense.Core
{
    public struct GoldChangedEvent : IEvent
    {
        public int Gold;

        public GoldChangedEvent(int gold)
        {
            Gold = gold;
        }
    }
}
