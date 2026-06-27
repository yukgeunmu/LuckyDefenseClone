using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Wave.Data
{
    [CreateAssetMenu(
        fileName = "WaveData",
        menuName = "Game/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [Header("Wave")]
        public int WaveNumber;

        [Header("Spawn")]
        public List<MonsterSpawnEntry> Monsters = new();

        [Header("Reward")]
        public int RewardSilver;

        [Header("Boss")]
        public bool IsBossWave;
    }
}