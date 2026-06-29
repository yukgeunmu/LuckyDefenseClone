using System.Collections.Generic;

namespace LuckyDefense.Heroes.Runtime
{
    public class ProjectileManager
    {
        private readonly List<Projectile> projectiles = new();

        public IReadOnlyList<Projectile> Projectiles => projectiles;

        public void Add(Projectile projectile)
        {
            projectiles.Add(projectile);
        }

        public void Remove(Projectile projectile)
        {
            projectiles.Remove(projectile);
        }
    }
}