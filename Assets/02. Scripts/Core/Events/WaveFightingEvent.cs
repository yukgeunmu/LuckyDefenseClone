using LuckyDefense.Wave.Data;
using UnityEngine;


namespace LuckyDefense.Core.Events
{
    public class WaveFightingEvent : IEvent
    {
        public WaveDataSO Wave;

        public WaveFightingEvent(WaveDataSO waveData)
        {
            Wave = waveData;
        }
    }

}
