using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Wave.Data
{
    [CreateAssetMenu(
        fileName = "WaveData",
        menuName = "Game/Wave/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [Header("Wave")]
        public int WaveNumber;

        [Header("Spawn")]
        public float SpawnInterval = 0.5f;
        public List<MonsterSpawnEntry> Monsters = new();
        public float Duration = 60.0f;

        [Header("Reward")]
        public int RewardSilver;

        [Header("Boss")]
        public bool IsBossWave;
    }
}