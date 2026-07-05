using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.Spawner
{
    public class MonsterSpawner : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Subscribe<WaveStartedEvent>(OnWaveStarted);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<WaveStartedEvent>(OnWaveStarted);
        }

        private void OnWaveStarted(IEvent e)
        {
            WaveStartedEvent evt = (WaveStartedEvent)e;

            GameManager.Instance.Spawn.StartWave(evt.Wave);
        }


    }
}