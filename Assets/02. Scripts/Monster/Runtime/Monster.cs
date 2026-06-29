using LuckyDefense.Monsters.Data;
using LuckyDefense.Core.Manager;
using LuckyDefense.Core.Events;

namespace LuckyDefense.Monsters
{
    public class Monster
    {
        public MonsterData Data { get; }

        public MonsterStats Stats { get; }

        public float HPPercent
        {
            get
            {
                return
                    (float)Stats.CurrentHP
                    / Stats.MaxHP;
            }
        }

        public bool IsDead => Stats.CurrentHP <= 0;

        public int CurrentPathIndex { get; set; }

        public Monster(MonsterData data)
        {
            Data = data;

            Stats = new MonsterStats(data);

            CurrentPathIndex = 1;
        }

        public void TakeDamage(int damage)
        {
            Stats.CurrentHP -= damage;

            EventBus.Publish(new MonsterDamagedEvent(this, damage));

            if (Stats.CurrentHP < 0)
            {
                Stats.CurrentHP = 0;
                EventBus.Publish(new MonsterDeadEvent(this));
            }

        }

        public void Heal(int amount)
        {
            Stats.CurrentHP += amount;

            if (Stats.CurrentHP > Stats.MaxHP)
                Stats.CurrentHP = Stats.MaxHP;
        }

        public void MoveNextPath()
        {
            if (CurrentPathIndex >= GameManager.Instance.Path.Count)
                CurrentPathIndex = 0;
            else
                CurrentPathIndex++;
        }
    }
}