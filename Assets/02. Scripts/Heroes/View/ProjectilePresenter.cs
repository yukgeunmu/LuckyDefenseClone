using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Runtime;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.View
{
    public class ProjectilePresenter : MonoBehaviour
    {
        [SerializeField]
        private ProjectileView projectilePrefab;

        private readonly Dictionary<Projectile, ProjectileView> projectileViews = new();

        private void Awake()
        {
            EventBus.Subscribe<ProjectileSpawnedEvent>(OnProjectileSpawned);

            EventBus.Subscribe<ProjectileDestroyedEvent>(OnProjectileDestroyed);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<ProjectileSpawnedEvent>(OnProjectileSpawned);

            EventBus.Unsubscribe<ProjectileDestroyedEvent>(OnProjectileDestroyed);
        }

        private void OnProjectileSpawned(IEvent e)
        {
            ProjectileSpawnedEvent evt = (ProjectileSpawnedEvent)e;

            ProjectileView view = Instantiate(
                GameManager.Instance.Data.GetProjectile(evt.Projectile.SkillProjectileType), 
                evt.Projectile.Position, 
                Quaternion.identity);

            view.Initialize(evt.Projectile);

            projectileViews.Add(evt.Projectile,view);
        }

        private void OnProjectileDestroyed(IEvent e)
        {
            ProjectileDestroyedEvent evt = (ProjectileDestroyedEvent)e;

            if (!projectileViews.TryGetValue(evt.Projectile,  out ProjectileView view))
                 return;
            
            Destroy(view.gameObject);

            projectileViews.Remove(evt.Projectile);
        }

        public ProjectileView GetView(Projectile projectile)
        {
            projectileViews.TryGetValue(projectile, out ProjectileView view);

            return view;
        }
    }
}