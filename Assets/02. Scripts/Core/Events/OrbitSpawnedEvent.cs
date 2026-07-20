using LuckyDefense.Heroes.Runtime;
using UnityEngine;

namespace LuckyDefense.Core.Events
{
    public struct OrbitSpawnedEvent : IEvent
    {
        public Orbit Orbit;

        public OrbitSpawnedEvent(Orbit orbit)
        {
            Orbit = orbit;
        }

    }

}
