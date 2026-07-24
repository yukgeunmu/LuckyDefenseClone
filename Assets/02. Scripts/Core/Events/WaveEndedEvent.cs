using LuckyDefense.Core;
using LuckyDefense.Wave.Data;

namespace LuckyDefense.Core.Events
{
    public struct WaveEndedEvent : IEvent
    {
        public WaveDataSO Wave;

        public WaveEndedEvent(WaveDataSO wave)
        {
            Wave = wave;
        }
    }
}