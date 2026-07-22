using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Skill.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.View
{
    public class ProjectilePresenter : MonoBehaviour
    {
        private readonly Dictionary<Projectile, ProjectileView> projectileViews = new();

        //private void Start()
        //{
        //    GameManager.Instance.Projectile.Initialize().Forget();
        //}

        private void OnEnable()
        {
            EventBus.Subscribe<ProjectileSpawnedEvent>(OnProjectileSpawned);

            EventBus.Subscribe<ProjectileDestroyedEvent>(OnProjectileDestroyed);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<ProjectileSpawnedEvent>(OnProjectileSpawned);

            EventBus.Unsubscribe<ProjectileDestroyedEvent>(OnProjectileDestroyed);
        }

        private void OnProjectileSpawned(IEvent e)
        {
            SpawnAsync((ProjectileSpawnedEvent)e).Forget();
        }

        private async UniTask SpawnAsync(IEvent e)
        {
            ProjectileSpawnedEvent evt = (ProjectileSpawnedEvent)e;

            ProjectileView view = await GameManager.Instance.Pool.Get<ProjectileView>(evt.ProjectilePrefab);
            
            view.Initialize(evt.Projectile);

            evt.Projectile.Ready();

            projectileViews.Add(evt.Projectile, view);

        }

        private void OnProjectileDestroyed(IEvent e)
        {
            ProjectileDestroyedEvent evt = (ProjectileDestroyedEvent)e;


            if (!projectileViews.TryGetValue(evt.Projectile, out ProjectileView view))
            {
                return;
            }

            GameManager.Instance.Pool.Release(view.gameObject);

            projectileViews.Remove(evt.Projectile);
        }

        public ProjectileView GetView(Projectile projectile)
        {
            projectileViews.TryGetValue(projectile, out ProjectileView view);

            return view;
        }
    }
}