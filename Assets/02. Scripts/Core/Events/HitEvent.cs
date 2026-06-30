using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Combat
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