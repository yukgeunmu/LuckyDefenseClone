using LuckyDefense.Core.Pool;
using LuckyDefense.Heroes.Runtime;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace LuckyDefense.Heroes.View
{
    public class ProjectileView : MonoBehaviour, IPoolable
    {
        private Projectile projectile;

        public void Initialize(Projectile projectile)
        {
            this.projectile = projectile;

            transform.position = projectile.Position;
        }

        public void OnDespawn()
        {
        }

        public void OnSpawn()
        {
        }

        private void Update()
        {
            if (projectile == null)
                return;

            transform.position = projectile.Position;

            transform.rotation = Quaternion.Euler(0, 0, projectile.Rotation + 180);

        }
    }
}