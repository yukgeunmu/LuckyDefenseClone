using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters.Data;
using UnityEngine;

public class MonsterDBTest : MonoBehaviour
{

    private void Awake()
    {
        EventBus.Subscribe<MonsterSpawnedEvent>(OnMonsterSpawned);
    }

    void Start()
    {
        MonsterData monsterData = GameManager.Instance.Data.GetMonster(1000);

        for (int i = 0; i < 5; i++)
        {
            GameManager.Instance.Spawn.SpawnMonster(monsterData);
        }

        Debug.Log(GameManager.Instance.Spawn.Monsters.Count);
    }


    private void OnMonsterSpawned(IEvent e)
    {
        MonsterSpawnedEvent evt =
            (MonsterSpawnedEvent)e;

        Debug.Log(
            $"Event : {evt.Monster.Data.MonsterName}");
    }

}
