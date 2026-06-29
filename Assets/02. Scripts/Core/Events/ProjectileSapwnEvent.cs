using LuckyDefense.Heroes.Runtime;
using UnityEngine;



namespace LuckyDefense.Core.Events
{
    public struct ProjectileSpawnedEvent : IEvent
    {
        public Projectile Projectile;

        public ProjectileSpawnedEvent(Projectile projectile)
        {
            Projectile = projectile;
        }
    }
}

