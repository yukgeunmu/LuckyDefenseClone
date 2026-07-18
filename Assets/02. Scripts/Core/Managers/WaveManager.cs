using LuckyDefense.Core.Events;
using LuckyDefense.UI.Scene;
using LuckyDefense.Wave.Data;
using System.Diagnostics;
using UnityEngine;

namespace LuckyDefense.Core.Manager
{
    public class WaveManager
    {
        public WaveState State { get; private set; }
        public int CurrentWave { get; private set; }

        public bool IsWaveWaiting=> State == WaveState.Waiting;

        public WaveData CurrentWaveData { get; private set; }

        public float WaveDuration => CurrentWaveData.Duration;

        public float ElapsedTime { get; private set; }

        public float RemainingTime => Mathf.Max(0, WaveDuration - ElapsedTime);


        public void StartGame()
        {
            CurrentWave = 1;
            StartWave(CurrentWave);
        }

        public bool StartWave(int wave)
        {
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


        public void NextWave()
        {
            CurrentWave++;
            ElapsedTime = 0;
            StartWave(CurrentWave);
        }

        public bool IsWaveCleared()
        {
            return GameManager.Instance
                .Spawn.AliveMonsterCount == 0;
        }

        public void Update()
        {
            if (IsWaveWaiting)
                return;          

            ElapsedTime += Time.deltaTime;
            GameManager.Instance.UI.Get<StatusUI>().SetTimer(RemainingTime);

            if (ElapsedTime >= WaveDuration)
            {
                NextWave();
            }
        }



        public void ChangeWaveState(WaveState state)
        {
            State = state;
        }

    }
}