using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Service
{
    public class CombatService
    {
        private readonly HeroCombatManager heroCombatManager;

        public CombatService(HeroCombatManager heroCombatManager)
        {
            this.heroCombatManager = heroCombatManager;

        }

        public void Update()
        {
            foreach (var pair in heroCombatManager.Combats)
            {
                HeroCombat combat = pair.Value;

                if (!combat.CanAttack())
                    continue;

                Hero hero = combat.Hero;

                Monster target = combat.PrimaryStrategy.FindTarget(hero);

                if (target == null)
                {
                    target =  combat.FallbackStrategy.FindTarget(hero);
                }


                if(target == null)
                    continue;

                GameManager.Instance.Projectile.Fire(hero, target);
            }
        }
    }
}