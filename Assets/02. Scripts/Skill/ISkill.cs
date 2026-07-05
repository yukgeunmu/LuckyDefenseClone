using LuckyDefense.Heroes;
using LuckyDefense.Skill.Data;

namespace LuckyDefense.Skill
{
    public interface ISkill
    {
        SkillData Data { get; }

        SkillCategory SkillType { get; }
    }
}