using LuckyDefense.Heroes;
using LuckyDefense.Skill.Data;

namespace LuckyDefense.Skill
{
    public interface ISkill
    {
        SkillDataSO Data { get; }

        SkillCategory SkillType { get; }
    }
}