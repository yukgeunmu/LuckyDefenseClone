using LuckyDefense.Skill.Data;
using LuckyDefense.Skill.Passive;

namespace LuckyDefense.Skill
{
    public class SkillFactory
    {
        public ISkill Create(SkillData data)
        {
            switch (data.SkillType)
            {
                // PASSIVE

                case SkillType.BonusDamage:
                    return new BonusDamageSkill((int)data.Value);

                case SkillType.Critical:
                    return new CriticalSkill(data.Value,2f);

                // ACTIVE

                case SkillType.Explosion:
                    return new ExplosionSkill(
                        data.Cooldown,
                        data.Radius,
                        (int)data.Value);

                case SkillType.Freeze:
                    return new FrozenSkill(
                        data.Cooldown,
                        data.Radius,
                        data.Value,
                        data.Duration);
                case SkillType.Stun:
                    return new StunSkill();

                default:
                    return null;
            }
        }
    }
}