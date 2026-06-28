using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Monsters.Factory;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterViewSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform monsterRoot;

        [SerializeField]
        private MonsterView monsterPrefab;

        private MonsterViewManager monsterViewManager;

        private void Awake()
        {
            monsterViewManager = new MonsterViewManager();
        }

        private void OnEnable()
        {
            EventBus.Subscribe<MonsterSpawnedEvent>(OnMonsterSpawned);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<MonsterSpawnedEvent>(OnMonsterSpawned);
        }


        private void OnMonsterSpawned(IEvent e)
        {
            MonsterSpawnedEvent evt = (MonsterSpawnedEvent)e;

            MonsterView view = Instantiate(monsterPrefab, monsterRoot);

            view.Initialize(evt.Monster);

            monsterViewManager.Add(evt.Monster, view);
        }
    }
}