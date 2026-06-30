using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Monsters;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Core.Service
{
    public class ProjectileService
    {
        private readonly HeroFactory heroFactory;

        private readonly ProjectileManager projectileManager;

        public ProjectileService(HeroFactory heroFactory, ProjectileManager projectileManager)
        {
            this.heroFactory = heroFactory;

            this.projectileManager = projectileManager;
        }

        public void Fire(Hero hero, Monster target)
        {
            Projectile projectile =
                heroFactory.CreateProjectile(hero, target);

            projectileManager.Add(projectile);

            EventBus.Publish(new ProjectileSpawnedEvent(projectile));
        }

        public void Update()
        {
            List<Projectile> removeList = new();

            foreach (var projectile in projectileManager.Projectiles)
            {
                if (projectile.Target == null)
                {
                    removeList.Add(projectile);

                    continue;
                }

                if (projectile.Target.IsDead)
                {
                    removeList.Add(projectile);
                    continue;
                }

                Vector3 next =
                    Vector3.MoveTowards(
                        projectile.Position,
                        projectile.Target.Position,
                        projectile.Speed *
                        Time.deltaTime);

                projectile.Move(next);

                float distance =
                    Vector3.Distance(
                        next,
                        projectile.Target.Position);

                if (distance < 0.1f)
                {
                    int damage = projectile.Owner.Stats.Attack;

                    foreach (var skill in projectile.Owner.SkillComponent.PassiveSkills)
                    {
                       damage = skill.ModifyDamage(projectile.Target, damage);
                    }

                    GameManager.Instance
                        .Damage
                        .DealDamage(
                            projectile.Owner,
                            projectile.Target,
                            damage);

                    removeList.Add(projectile);
                }
            }

            foreach (var projectile in removeList)
            {
                projectile.Destroy();

                projectileManager.Remove(projectile);

                EventBus.Publish(new ProjectileDestroyedEvent(projectile));
            }
        }
    }
}