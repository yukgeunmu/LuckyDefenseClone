using LuckyDefense.Heroes;
using LuckyDefense.Skill.Passive;
using System.Collections.Generic;

namespace LuckyDefense.Skill
{
    public class HeroSkillComponent
    {
        public List<PassiveSkill> PassiveSkills = new();

        public List<ActiveSkill> ActiveSkills = new();

        private Hero owner;

        public HeroSkillComponent(Hero owner)
        {
            this.owner = owner;
        }


        public void ApplyPassives()
        {
            foreach (var passive in PassiveSkills)
            {
                passive.Apply(owner);
            }
        }

        public void RemovePassives()
        {
            foreach (var passive in PassiveSkills)
            {
                passive.Remove(owner);
            }
        }

        public int ModifyDamage(Hero owner,int damage)
        {
            int result = damage;

            foreach (var passive in PassiveSkills)
            {
                result = passive.ModifyDamage(owner, result);
            }

            return result;
        }

    }
}