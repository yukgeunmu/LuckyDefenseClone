using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Manager;
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
                
                Monster target = combat.FindTarget();

                if (target == null)
                {
                    continue;
                }

                int damage = combat.Hero.Stats.Attack;

                damage = combat.Hero.SkillComponent.ModifyDamage(combat.Hero,damage);

                GameManager.Instance.Projectile.Fire(combat.Hero,target, damage);
            }
        }
    }
}