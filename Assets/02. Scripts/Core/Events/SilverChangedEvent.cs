using LuckyDefense.Core;
using System.Diagnostics;


namespace LuckyDefense.Core
{
    public struct SilverChangedEvent : IEvent
    {
        public int Silver;

        public SilverChangedEvent(int silver)
        {
            Silver = silver;
        }
    }
}
