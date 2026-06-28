
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

public class WaveTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        EventBus.Subscribe<MonsterSpawnedEvent>(OnMonsterSpawned);

        GameManager.Instance.Wave.StartGame();
    }

    private void OnMonsterSpawned(IEvent e)
    {
        MonsterSpawnedEvent evt =(MonsterSpawnedEvent)e;

        Debug.Log(
            $"Spawn : "
            + evt.Monster.Data.MonsterName);
    }


}
