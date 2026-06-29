using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Monsters.View;
using UnityEditor.Build.Pipeline.Injector;
using UnityEngine;

namespace LuckyDefense.Core.Service
{
    public class TargetService
    {
        public Monster FindTarget(Hero hero)
        {
            Monster target = null;

            int highestPath = -1;

            Vector3 heroPos = hero.CurrentCell.WorldPosition;

            float range = hero.Stats.Range;


            foreach (Monster monster in GameManager.Instance.Spawn.Monsters)
            {
                if (monster.IsDead)
                    continue;

                float distance = Vector3.Distance(heroPos, monster.Position);

                if (distance > range)
                    continue;

                if(monster.CurrentPathIndex > highestPath)
                {
                    highestPath = monster.CurrentPathIndex;

                    target = monster;
                }
            }

            return target;
        }
    }
}