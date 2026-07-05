using LuckyDefense.Wave.Data;


namespace LuckyDefense.Core.Events
{
    public class WaveClearedEvent : IEvent
    {
        public WaveData Wave;

        public WaveClearedEvent(WaveData waveData)
        {
            Wave = waveData;
        }
    }

}
