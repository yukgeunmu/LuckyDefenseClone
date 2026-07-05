using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Skill;
using LuckyDefense.Skill.Data;
using UnityEngine;


namespace LuckyDefense.Skill.Active
{
    public class SummonSkill : ActiveSkill
    {
        public SummonSkill(SkillData data) : base(data)
        {
        }

        public override void Execute(Hero hero, Monster target)
        {
            if (!CanCast())
                return;

            ResetCooldown();
        }
    }
}

