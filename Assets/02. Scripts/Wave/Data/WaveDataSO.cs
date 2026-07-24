using LuckyDefense.Core;
using LuckyDefense.Monsters.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Wave.Data
{
    [CreateAssetMenu(
        fileName = "WaveData",
        menuName = "Game/Wave/Wave Data")]
    public class WaveDataSO : ScriptableObject, IDataSO
    {
        [Header("Wave")]
        public int WaveID;
        public int WaveNumber;
        public int ID => WaveID;

        [Header("Spawn")]
        public MonsterDataSO Monster;
        public int Count = 1;
        public float SpawnInterval = 0.5f;
        public float Duration = 60.0f;


        [Header("Reward")]
        public int RewardSilver;

        [Header("Boss")]
        public bool IsBossWave;
    }
}