using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterViewSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform monsterRoot;

        [SerializeField]
        private MonsterView monsterPrefab;


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

           GameManager.Instance.MonsterView.Add(evt.Monster, view);
        }
    }
}