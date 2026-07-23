using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;



namespace LuckyDefense.Skill.Active
{
    public class AuraSkill : ActiveSkill
    {
        public AuraSkill(SkillDataSO data) : base(data)
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

