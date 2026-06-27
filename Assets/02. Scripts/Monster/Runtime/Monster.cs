using LuckyDefense.Monsters.Data;

namespace LuckyDefense.Monsters
{
    public class Monster
    {
        public MonsterData Data { get; }

        public MonsterStats Stats { get; }

        public bool IsDead => Stats.CurrentHP <= 0;

        public int CurrentPathIndex { get; set; }

        public Monster(MonsterData data)
        {
            Data = data;

            Stats = new MonsterStats(data);

            CurrentPathIndex = 0;
        }

        public void TakeDamage(int damage)
        {
            Stats.CurrentHP -= damage;

            if (Stats.CurrentHP < 0)
                Stats.CurrentHP = 0;
        }

        public void Heal(int amount)
        {
            Stats.CurrentHP += amount;

            if (Stats.CurrentHP > Stats.MaxHP)
                Stats.CurrentHP = Stats.MaxHP;
        }
    }
}