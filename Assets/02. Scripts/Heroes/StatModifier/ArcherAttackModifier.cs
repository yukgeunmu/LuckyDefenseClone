using LuckyDefense.Heroes.Data;
using UnityEngine;


namespace LuckyDefense.Heroes.StatModifier
{
    public class ArcherAttackModifier : IHeroStatModifier
    {
        public void Apply(HeroStats stats)
        {
            stats.Attack = Mathf.RoundToInt(stats.Attack * 1.2f);
        }

        public void Remove(HeroStats stats)
        {
        }
    }
}
