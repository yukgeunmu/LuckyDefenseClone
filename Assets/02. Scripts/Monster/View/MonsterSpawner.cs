using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Wave.Data;
using System.Collections;
using UnityEngine;

namespace LuckyDefense.Monsters
{
    public class MonsterSpawner : MonoBehaviour
    {

        public float StartDelay;

        private Coroutine spawnRoutine;

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

            if (spawnRoutine != null) StopCoroutine(spawnRoutine);

            spawnRoutine = StartCoroutine(SpawnWave(evt.Wave));
        }

        private IEnumerator SpawnWave(WaveData wave)
        {
            yield return new WaitForSeconds(StartDelay);

            foreach (var entry in wave.Monsters)
            {
                for (int i = 0; i < entry.Count; i++)
                {
                    GameManager.Instance
                        .Spawn
                        .SpawnMonster(
                            entry.Monster);

                    yield return
                        new WaitForSeconds(
                            entry.SpawnInterval);
                }
            }
        }

        public void StopSpawn()
        {
            if (spawnRoutine != null)
            {
                StopCoroutine(spawnRoutine);
                spawnRoutine = null;
            }
        }
    }
}