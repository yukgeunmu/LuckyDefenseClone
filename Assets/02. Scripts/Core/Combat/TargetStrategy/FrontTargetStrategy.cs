using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.Core.Combat
{
    public class FrontTargetStrategy : ITargetStrategy
    {
        public Monster FindTarget(Hero hero)
        {
            Monster result = null;

            int highestPath = -1;

            Vector3 heroPos = hero.CurrentCell.WorldPosition;

            float range = hero.Stats.Range;

            foreach (Monster monster in GameManager.Instance.Spawn.Monsters)
            {
                if (monster.IsDead)
                {
                    continue;
                }


                float distance = Vector3.Distance(heroPos, monster.Position);

                if (distance > range)
                {
                    continue;
                }


                if (monster.CurrentPathIndex > highestPath)
                {
                    highestPath =
                        monster.CurrentPathIndex;

                    result = monster;
                }
            }

            return result;
        }
    }
}