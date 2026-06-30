using LuckyDefense.Skill.Passive;
using System.Collections.Generic;

namespace LuckyDefense.Skill
{
    public class HeroSkillComponent
    {
        public List<PassiveSkill> PassiveSkills = new();

        public List<ActiveSkill> ActiveSkills = new();
    }
}