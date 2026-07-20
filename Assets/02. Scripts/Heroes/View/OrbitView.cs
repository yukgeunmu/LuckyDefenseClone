using LuckyDefense.Core.Pool;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Monsters.View;
using UnityEngine;

namespace LuckyDefense.Heroes.View
{
    public class OrbitView : MonoBehaviour, IPoolable
    {
        private Orbit orbit;

        public void Initialize(Orbit orbit)
        {
            this.orbit = orbit;

            transform.position = orbit.Position;

        }

        public void OnDespawn()
        {
        }

        public void OnSpawn()
        {
        }

        private void Update()
        {
            if (orbit == null)
                return;

            transform.position = orbit.Position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MonsterView monsterView))
            {
                orbit.Hit(monsterView.Monster);
            }
        }
    }
}

