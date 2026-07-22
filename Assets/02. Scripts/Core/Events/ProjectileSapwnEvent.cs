using LuckyDefense.Heroes.Runtime;
using UnityEngine;
using UnityEngine.AddressableAssets;



namespace LuckyDefense.Core.Events
{
    public struct ProjectileSpawnedEvent : IEvent
    {
        public Projectile Projectile;

        public AssetReferenceGameObject ProjectilePrefab;

        public ProjectileSpawnedEvent(Projectile projectile, AssetReferenceGameObject projectilePrefab)
        {
            Projectile = projectile;
            ProjectilePrefab = projectilePrefab;
        }
    }
}

