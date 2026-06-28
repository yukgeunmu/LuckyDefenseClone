using LuckyDefense.Core;
using LuckyDefense.Wave.Data;

namespace LuckyDefense.Core.Events
{
    public struct WaveEndedEvent : IEvent
    {
        public WaveData Wave;

        public WaveEndedEvent(WaveData wave)
        {
            Wave = wave;
        }
    }
}