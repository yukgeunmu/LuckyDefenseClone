using LuckyDefense.Wave.Data;

namespace LuckyDefense.Core.Events
{
    public struct WaveStartedEvent : IEvent
    {
        public WaveData Wave;

        public WaveStartedEvent(WaveData wave)
        {
            Wave = wave;
        }
    }
}