using LuckyDefense.Core.Combat;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Monsters;
using LuckyDefense.Skill;
using LuckyDefense.Skill.Data;
using LuckyDefense.Skill.Passive;

namespace LuckyDefense.Heroes.Factory
{
    public class HeroFactory
    {
        private readonly SkillFactory skillFactory;

        public HeroFactory(SkillFactory skillFactory)
        {
            this.skillFactory = skillFactory;
        }


        public Hero Create(HeroData heroData)
        {
            Hero hero = new Hero(heroData);

            HeroSkillComponent skillComponent = new HeroSkillComponent(hero);


            foreach (var skillData in heroData.PassiveSkills)
            {
                ISkill skill = skillFactory.Create(skillData);

                if (skill is PassiveSkill passive)
                {
                    skillComponent.PassiveSkills.Add(passive);
                }
            }

            foreach (var skillData in heroData.ActiveSkills)
            {
                ISkill skill = skillFactory.Create(skillData);

                if (skill is ActiveSkill active)
                {
                    skillComponent.ActiveSkills.Add(active);
                }
            }

            hero.SkillComponent = skillComponent;


            ITargetStrategy primary = CreateTargetStrategy(heroData.PrimaryTarget);
            ITargetStrategy fallback = CreateTargetStrategy(heroData.FallbackTarget);

            hero.Combat = new HeroCombat(hero, primary, fallback);

            return hero;
        }

        public ITargetStrategy CreateTargetStrategy(TargetType targetType)
        {
            switch (targetType)
            {
                case TargetType.Front:
                    return new FrontTargetStrategy();

                case TargetType.Nearest:
                    return new NearestTargetStrategy();

                //case TargetType.LowestHP:
                //    return new LowestHPTargetStrategy();

                //case TargetType.HighestHP:
                //    return new HighestHPTargetStrategy();

                //case TargetType.Random:
                //    return new RandomTargetStrategy();

                //case TargetType.Boss:
                //    return new BossTargetStrategy();

                default:
                    return new FrontTargetStrategy();
            }
        }
        public Projectile CreateProjectile(Hero hero, Monster target, ProjectileType skillProjectileType = ProjectileType.None)
        {

            return new Projectile(
                hero,
                target,
                hero.CurrentCell.WorldPosition,
                hero.Data.ProjectileSpeed,
                skillProjectileType);
        }
    }
}