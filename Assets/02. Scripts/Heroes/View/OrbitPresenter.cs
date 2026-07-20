using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Skill.Data;
using System.Collections.Generic;
using UnityEngine;


namespace LuckyDefense.Heroes.View
{
    public class OrbitPresenter : MonoBehaviour
    {
        private readonly Dictionary<Orbit, OrbitView> orbitViews = new();

        private void OnEnable()
        {
            EventBus.Subscribe<OrbitSpawnedEvent>(OnOrbitSpawned);

            EventBus.Subscribe<OrbitDestroyedEvent>(OnOrbitDestroyed);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<OrbitSpawnedEvent>(OnOrbitSpawned);

            EventBus.Unsubscribe<OrbitDestroyedEvent>(OnOrbitDestroyed);
        }

        private void OnOrbitSpawned(IEvent e)
        {
            SpawnAsync((OrbitSpawnedEvent)e).Forget();
        }

        private async UniTask SpawnAsync(OrbitSpawnedEvent evt)
        {
            OrbitConfig config = GameManager.Instance.Data.GetOrbit(evt.Orbit.Type);

            OrbitView view = await GameManager.Instance.Pool.Get<OrbitView>(config.ViewPrefab);

            view.Initialize(evt.Orbit);

            orbitViews.Add(evt.Orbit, view);

        }

        private void OnOrbitDestroyed(IEvent e)
        {
            OrbitDestroyedEvent evt = (OrbitDestroyedEvent)e;


            if (!orbitViews.TryGetValue(evt.Orbit, out OrbitView view))
            {
                return;
            }

            GameManager.Instance.Pool.Release(view.gameObject);

            orbitViews.Remove(evt.Orbit);
        }
    }

}
