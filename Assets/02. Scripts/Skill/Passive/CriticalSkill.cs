using LuckyDefense.Monsters;
using LuckyDefense.Skill.Passive;
using UnityEngine;

namespace LuckyDefense.Skill
{
    public class CriticalSkill : PassiveSkill
    {
        private readonly float chance;

        private readonly float multiplier;

        public CriticalSkill( float chance, float multiplier)
        {
            this.chance = chance;
            this.multiplier = multiplier;
        }

        public override int ModifyDamage( Monster target, int damage)
        {
            if (Random.value > chance)
                return damage;

            return (int)(damage * multiplier);
        }
    }
}