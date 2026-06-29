using LuckyDefense.Core.Combat;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Monsters;
using NUnit.Framework.Constraints;

namespace LuckyDefense.Heroes.Factory
{
    public class HeroFactory
    {
        public Hero Create(HeroData heroData)
        {
            return new Hero(heroData);
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
        public Projectile CreateProjectile(Hero hero, Monster target)
        {
            return new Projectile(
                hero,
                target,
                hero.CurrentCell.WorldPosition,
                hero.Data.ProjectileSpeed);
        }
    }
}