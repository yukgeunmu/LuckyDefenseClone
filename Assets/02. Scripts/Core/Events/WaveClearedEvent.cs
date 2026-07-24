using LuckyDefense.Wave.Data;


namespace LuckyDefense.Core.Events
{
    public class WaveClearedEvent : IEvent
    {
        public WaveDataSO Wave;

        public WaveClearedEvent(WaveDataSO waveData)
        {
            Wave = waveData;
        }
    }

}
