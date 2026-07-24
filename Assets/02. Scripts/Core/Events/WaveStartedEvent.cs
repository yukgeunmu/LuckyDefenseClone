using LuckyDefense.Wave.Data;

namespace LuckyDefense.Core.Events
{
    public struct WaveStartedEvent : IEvent
    {
        public WaveDataSO Wave;

        public WaveStartedEvent(WaveDataSO wave)
        {
            Wave = wave;
        }
    }
}