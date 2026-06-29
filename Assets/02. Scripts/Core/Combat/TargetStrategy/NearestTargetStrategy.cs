using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.Core.Combat
{
    public class NearestTargetStrategy : ITargetStrategy
    {
        public Monster FindTarget(Hero hero)
        {
            Monster result = null;

            float nearest = float.MaxValue;

            Vector3 heroPos = hero.CurrentCell.WorldPosition;

            float range = hero.Stats.Range;

            foreach (Monster monster in GameManager.Instance.Spawn.Monsters)
            {
                if (monster.IsDead)
                    continue;

                float distance =
                    Vector3.Distance(
                        heroPos,
                        monster.Position);

                if (distance > range)
                    continue;

                if (distance < nearest)
                {
                    nearest = distance;
                    result = monster;
                }
            }

            return result;
        }
    }
}