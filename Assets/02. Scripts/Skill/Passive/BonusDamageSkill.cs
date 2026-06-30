using LuckyDefense.Monsters;

namespace LuckyDefense.Skill.Passive
{
    public class BonusDamageSkill : PassiveSkill
    {
        private readonly int bonus;

        public BonusDamageSkill(int bonus)
        {
            this.bonus = bonus;
        }

        public override int ModifyDamage(Monster target, int damage)
        {
            return damage + bonus;
        }

    }
}