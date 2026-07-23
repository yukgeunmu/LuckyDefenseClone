using LuckyDefense.Heroes;
using LuckyDefense.Skill.Data;

namespace LuckyDefense.Skill.Passive
{
    public class StatPassiveSkill : PassiveSkill
    {
        public StatPassiveSkill(SkillDataSO data) : base(data)
        {
        }

        public override void Apply(Hero hero)
        {
            switch (Data.LogicType)
            {
                case SkillLogicType.AttackUp:
                    hero.Stats.Attack += (int)Data.Value;
                    break;

                case SkillLogicType.AttackSpeedUp:
                    hero.Stats.AttackSpeed += Data.Value;
                    break;
            }
        }

    }
}


