using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;


namespace LuckyDefense.Core.Service
{
    public class DamageService
    {
        public DamageResult DealDamage(Hero attacker, Monster target, int damage)
        {
            if (target == null)
                return new DamageResult(0, false);

            if (target.IsDead)
                return new DamageResult(0, true);

            target.TakeDamage(damage);

            EventBus.Publish(new MonsterDamagedEvent(target, damage, false, target.Position));

            if (target.IsDead)
            {
                EventBus.Publish( new MonsterDeadEvent(target));
            }

            return new DamageResult(damage, target.IsDead);
        }
    }

}
