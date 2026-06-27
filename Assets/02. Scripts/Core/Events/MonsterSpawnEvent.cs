using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Events
{
    public struct MonsterSpawnedEvent : IEvent
    {
        public Monster Monster;

        public MonsterSpawnedEvent(Monster monster)
        {
            Monster = monster;
        }
    }
}