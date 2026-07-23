using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;
using LuckyDefense.StatusEffects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

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


        public void Fire(Hero hero, Monster target, int damage)
        {
            Projectile projectile = heroFactory.CreateProjectile(hero, target);

            projectile.OnHit = p =>
            {
                GameManager.Instance.Damage.DealDamage(
                    p.Target,
                    damage
                    );
            };


            Spawn(projectile, hero.Data.ProjectilePrefab);

        }

        public void FireSkill(
            Hero hero,
            Monster target,
            SkillDataSO skillData)
        {
            Projectile projectile = heroFactory.CreateProjectile(hero, target);

            projectile.OnHit = p =>
            {
                GameManager.Instance.Damage.DealDamage(
                    p.Target,
                    (int)skillData.Value
                    );

                if (skillData.StatusEffectType != StatusEffectType.None)
                {
                    GameManager.Instance.StatusEffect.Apply(
                        target,
                        skillData.StatusEffectType,
                        skillData.Duration,
                        skillData.StatusEffectValue
                        );
                }
            };


            Spawn(projectile, skillData.ProjectilePrefab);

        }


        public void Spawn(Projectile projectile, AssetReferenceGameObject prefab)
        {
            projectileManager.Add(projectile);

            EventBus.Publish(new ProjectileSpawnedEvent(projectile, prefab));
        }



        public void Update()
        {
            List<Projectile> removeList = new();

            foreach (var projectile in projectileManager.Projectiles)
            {
                if (!projectile.IsReady)
                    continue;


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
                    projectile.Hit();

                    removeList.Add(projectile);
                }
            }

            foreach (var projectile in removeList)
            {
                projectileManager.Remove(projectile);

                EventBus.Publish(new ProjectileDestroyedEvent(projectile));
            }
        }
    }
}