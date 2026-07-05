using LuckyDefense.Core.Events;
using LuckyDefense.Wave.Data;

namespace LuckyDefense.Core.Manager
{
    public class WaveManager
    {
        public WaveState State { get; private set; }
        public int CurrentWave { get; private set; }

        public bool IsWaveRunning => State != WaveState.Waiting && State != WaveState.Finished;

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

            State = WaveState.Spawning;

            CurrentWave = wave;

            CurrentWaveData = data;


            EventBus.Publish(new WaveStartedEvent(data));

            return true;
        }

        public void EndWave()
        {
            if (!IsWaveRunning)
                return;

            State = WaveState.Waiting;

            GameManager.Instance.Spawn.ClearMonster();

            EventBus.Publish( new WaveEndedEvent(CurrentWaveData));
        }

        public void NextWave()
        {
            CurrentWave++;

            StartWave(CurrentWave);
        }

        public bool IsWaveCleared()
        {
            return GameManager.Instance
                .Spawn.AliveMonsterCount == 0;
        }

        public void Update()
        {
            if (!IsWaveRunning)
                return;

            switch (State)
            {
                case WaveState.Spawning:
                    UpdateSpawning();
                    break;

                case WaveState.Fighting: 
                    UpdateFighting();
                    break;
            }
        }

        private void UpdateSpawning()
        {
            if (!GameManager.Instance.Spawn.IsSpawnFinished)
                return;

            State = WaveState.Fighting;

            EventBus.Publish(new WaveFightingEvent(CurrentWaveData));
        }


        private void UpdateFighting()
        {
            if (!IsWaveCleared())
                return;

            ClearWave();
        }

        private void ClearWave()
        {
            State = WaveState.Reward;

            EndWave();

            EventBus.Publish( new WaveClearedEvent(CurrentWaveData));
        }


    }
}