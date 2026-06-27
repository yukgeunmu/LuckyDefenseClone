using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Wave.Data
{
    [CreateAssetMenu(
        fileName = "WaveDatabase",
        menuName = "Game/Wave Database")]
    public class WaveDatabase : ScriptableObject
    {
        public List<WaveData> Waves = new();
    }
}