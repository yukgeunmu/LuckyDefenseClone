using LuckyDefense.Heroes.Data;
using UnityEngine;



namespace LuckyDefense.Heroes.Data
{
    [System.Serializable]
    public class HeroStats
    {
        public int Attack;

        public float AttackSpeed;

        public float Range;

        public HeroStats()
        {
        }

        public HeroStats(HeroData data)
        {
            Attack = data.AttackPower;
            AttackSpeed = data.AttackSpeed;
            Range = data.Range;
        }

        public HeroStats Clone()
        {
            return new HeroStats
            {
                Attack = Attack,
                AttackSpeed = AttackSpeed,
                Range = Range
            };
        }
    }
}

