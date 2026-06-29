using LuckyDefense.Core.Combat;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Service
{
    public class CombatService
    {
        private readonly HeroCombatManager heroCombatManager;

        private readonly TargetService targetService;

        private readonly DamageService damageService;

        public CombatService(HeroCombatManager heroCombatManager, TargetService targetService, DamageService damageService)
        {
            this.heroCombatManager = heroCombatManager;

            this.targetService = targetService;

            this.damageService = damageService;
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

                damageService.DealDamage( hero,target);
            }
        }
    }
}