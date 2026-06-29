using LuckyDefense.Core.Events;
using LuckyDefense.Wave.Data;

namespace LuckyDefense.Core.Manager
{
    public class WaveManager
    {
        public int CurrentWave { get; private set; }

        public bool IsWaveRunning { get; private set; }

        public WaveData CurrentWaveData { get; private set; }

        public void StartGame()
        {
            CurrentWave = 1;

            StartWave(CurrentWave);
        }

        public bool StartWave(int wave)
        {
            if (IsWaveRunning)
                return false;

            WaveData data =
                GameManager.Instance
                    .Data
                    .GetWave(wave);

            if (data == null)
                return false;

            CurrentWave = wave;

            CurrentWaveData = data;

            IsWaveRunning = true;

            EventBus.Publish(new WaveStartedEvent(data));

            return true;
        }

        public void EndWave()
        {
            if (!IsWaveRunning)
                return;

            IsWaveRunning = false;

            EventBus.Publish(
                new WaveEndedEvent(
                    CurrentWaveData));
        }

        public void NextWave()
        {
            StartWave(CurrentWave + 1);
        }

        public bool IsWaveCleared()
        {
            return GameManager.Instance
                .Spawn
                .Monsters
                .Count == 0;
        }
    }
}