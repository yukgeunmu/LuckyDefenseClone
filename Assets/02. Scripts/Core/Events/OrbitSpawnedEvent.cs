using LuckyDefense.Heroes.Runtime;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Core.Events
{
    public struct OrbitSpawnedEvent : IEvent
    {
        public Orbit Orbit;

        public AssetReferenceGameObject OrbitPrefab;

        public OrbitSpawnedEvent(Orbit orbit, AssetReferenceGameObject prefab)
        {
            Orbit = orbit;
            OrbitPrefab = prefab;
        }

    }

}
