using LuckyDefense.Monsters.Data;
using System;

namespace LuckyDefense.Wave.Data
{
    [Serializable]
    public class MonsterSpawnEntry
    {
        public MonsterDataSO Monster;

        public int Count = 1;

        public float SpawnInterval = 0.5f;
    }
}