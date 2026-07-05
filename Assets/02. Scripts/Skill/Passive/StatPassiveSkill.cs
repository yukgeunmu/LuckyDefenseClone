using LuckyDefense.Heroes;
using LuckyDefense.Skill.Data;

namespace LuckyDefense.Skill.Passive
{
    public class StatPassiveSkill : PassiveSkill
    {
        public StatPassiveSkill(SkillData data) : base(data)
        {
        }

        public override void Apply(Hero hero)
        {
            switch (Data.SkillName)
            {
                case "AttackUp":
                    hero.Stats.Attack += (int)Data.Value;
                    break;

                case "AttackSpeedUp":
                    hero.Stats.AttackSpeed += Data.Value;
                    break;
            }
        }

    }
}


