using LuckyDefense.Heroes.Runtime;
using UnityEngine;

namespace LuckyDefense.Core.Events
{
    public struct OrbitDestroyedEvent : IEvent
    {
        public Orbit Orbit;

        public OrbitDestroyedEvent(Orbit orbit)
        {
            Orbit = orbit;
        }
    }
}

