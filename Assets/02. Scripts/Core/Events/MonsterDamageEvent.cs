using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Events
{
    public struct MonsterDamagedEvent: IEvent
    {
        public Monster Monster;

        public int Damage;

        public MonsterDamagedEvent(Monster monster,int damage)
        {
            Monster = monster;
            Damage = damage;
        }
    }
}