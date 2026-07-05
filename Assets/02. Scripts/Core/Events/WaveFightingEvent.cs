using LuckyDefense.Wave.Data;
using UnityEngine;


namespace LuckyDefense.Core.Events
{
    public class WaveFightingEvent : IEvent
    {
        public WaveData Wave;

        public WaveFightingEvent(WaveData waveData)
        {
            Wave = waveData;
        }
    }

}
