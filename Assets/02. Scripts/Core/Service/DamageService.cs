using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;


namespace LuckyDefense.Core.Service
{
    public class DamageSystem
    {
        public void DealDamage(Hero hero, Monster monster)
        {
            if (monster == null)
                return;

            if (monster.IsDead)
                return;

            monster.TakeDamage(hero.Stats.Attack);

            if (monster.IsDead)
            {
                EventBus.Publish(
                    new MonsterDeadEvent(
                        monster));

                GameManager.Instance
                    .Spawn
                    .RemoveMonster(
                        monster);
            }
        }
    }
}
