using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Core.Combat
{
    public class RandomTargetStrategy : ITargetStrategy
    {
        public Monster FindTarget(Hero hero)
        {
            List<Monster> targets = new();

            Vector3 heroPos = hero.CurrentCell.WorldPosition;

            float range = hero.Stats.Range;

            foreach (Monster monster in GameManager.Instance.Spawn.Monsters)
            {
                if (monster.IsDead)
                    continue;

                float distance =  Vector3.Distance( heroPos, monster.Position);

                if (distance <= range)
                    targets.Add(monster);
            }

            if (targets.Count == 0)
                return null;

            return targets[Random.Range(0,targets.Count)];
        }
    }
}