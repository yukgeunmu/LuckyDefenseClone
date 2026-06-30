using LuckyDefense.Heroes;
using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Combat
{
    public class HeroCombat
    {
        public Hero Hero { get; }

        public ITargetStrategy PrimaryStrategy { get; }

        public ITargetStrategy FallbackStrategy { get; }


        private float attackTimer;

        public HeroCombat(Hero hero, ITargetStrategy primary, ITargetStrategy fallback)
        {
            Hero = hero;
            PrimaryStrategy = primary;
            FallbackStrategy = fallback;
        }

        public bool CanAttack()
        {
            attackTimer += UnityEngine.Time.deltaTime;

            float cooldown = 1f / Hero.Stats.AttackSpeed;

            if (attackTimer < cooldown)
                return false;

            attackTimer = 0;

            return true;
        }

        public Monster FindTarget()
        {
            Monster target = PrimaryStrategy.FindTarget(Hero);

            if (target == null)
            {
                target = FallbackStrategy.FindTarget(Hero);
            }

            return target;
        }
    }
}