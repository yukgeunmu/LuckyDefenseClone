using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Events
{
    public struct HitEvent : IEvent
    {
        public Monster Monster;

        public HitEvent(Monster monster)
        {
            Monster = monster;
        }
    }
}