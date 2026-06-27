using LuckyDefense.Core.Manager;
using LuckyDefense.Wave.Data;
using UnityEngine;

public class WaveTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveData wave = GameManager.Instance .Data.GetWave(1);

        Debug.Log(
            $"Wave : {wave.WaveNumber}");

        foreach (var spawn in wave.Monsters)
        {
            Debug.Log(
                $"{spawn.Monster.MonsterName} "
                + $"{spawn.Count}");
        }
    }


}
