using LuckyDefense.Core.Events;
using LuckyDefense.Monsters.Data;

namespace LuckyDefense.Monsters.Factory
{
    public class MonsterFactory
    {
        public Monster Create(MonsterDataSO data)
        {
            return new Monster(data); ;
        }
    }
}