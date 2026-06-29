using LuckyDefense.Heroes.Runtime;
using UnityEngine;

namespace LuckyDefense.Heroes.View
{
    public class ProjectileView : MonoBehaviour
    {
        private Projectile projectile;

        public void Initialize(Projectile projectile)
        {
            this.projectile = projectile;

            transform.position = projectile.Position;
        }

        private void Update()
        {
            if (projectile == null)
                return;

            transform.position = projectile.Position;
        }
    }
}