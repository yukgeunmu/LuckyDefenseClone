using LuckyDefense.Heroes.Runtime;
using UnityEngine;


namespace LuckyDefense.Core.Events
{
    public struct ProjectileDestroyedEvent : IEvent
    {
        public Projectile Projectile;

        public ProjectileDestroyedEvent(
            Projectile projectile)
        {
            Projectile = projectile;
        }
    }
}


