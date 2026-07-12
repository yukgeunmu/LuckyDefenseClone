using LuckyDefense.UI;


namespace LuckyDefense.Core.Events
{
    public struct DamageTextExpiredEvent : IEvent
    {
        public DamageTextView TextView { get; private set; }

        public DamageTextExpiredEvent(DamageTextView textView)
        {
            this.TextView = textView;
        }
    }
}

