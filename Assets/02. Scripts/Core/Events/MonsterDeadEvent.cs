using LuckyDefense.Monsters;



namespace LuckyDefense.Core.Events
{
    public struct MonsterDeadEvent : IEvent
    {
        public Monster Monster;

        public MonsterDeadEvent(Monster monster)
        {
            Monster = monster;
        }
    }
}
