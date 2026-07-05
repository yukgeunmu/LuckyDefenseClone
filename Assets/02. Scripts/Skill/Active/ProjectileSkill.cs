using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;


namespace LuckyDefense.Skill.Active
{
    public class ProjectileSkill : ActiveSkill
    {

        public ProjectileSkill(SkillData data) : base(data)
        {
        }

        public override void Execute(Hero hero, Monster target)
        {
            if (!CanCast())
                return;

            ResetCooldown();

            GameManager.Instance.Projectile.FireSkill(hero, target, Data);
        }
    }
}

