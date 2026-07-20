using LuckyDefense.Core.Manager;
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

        public bool FindTarget(out Monster target)
        {
            target = PrimaryStrategy.FindTarget(Hero) ?? FallbackStrategy.FindTarget(Hero);

            return target != null;
        }

        public bool TryAcquireTarget()
        {
            if (!FindTarget(out Monster target))
                return false;

            Hero.Target = target;

            return true;
        }

        public void Attack(Monster target)
        {
            if (!CanAttack())
                return;

            int damage = Hero.Stats.Attack;

            damage = Hero.SkillComponent.ModifyDamage(Hero, damage);

            GameManager.Instance.Projectile.Fire(
                Hero,
                target,
                damage);
        }
    }
}