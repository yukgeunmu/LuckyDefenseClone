namespace LuckyDefense.Monsters.Data
{
    [System.Serializable]
    public class MonsterStats
    {
        public int MaxHP;

        public int CurrentHP;

        public int Attack;

        public float MoveSpeed;


        public MonsterStats()
        {
        }

        public MonsterStats(MonsterDataSO data)
        {
            MaxHP = data.MaxHp;
            CurrentHP = data.MaxHp;
            Attack = data.Attack;
            MoveSpeed = data.MoveSpeed;
        }

        public MonsterStats Clone()
        {
            return new MonsterStats
            {
                MaxHP = MaxHP,
                CurrentHP = CurrentHP,
                Attack = Attack,
                MoveSpeed = MoveSpeed,
            };
        }
    }
}