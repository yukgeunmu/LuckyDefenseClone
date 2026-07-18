using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.UI.Base;
using TMPro;
using UnityEngine;

namespace LuckyDefense.UI.Scene
{
    public class StatusUI : SceneUI
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI monsterCountText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private RectTransform fill;


        private void OnEnable()
        {
            EventBus.Subscribe<GoldChangedEvent>(ChangeGoldText);
            EventBus.Subscribe<WaveStartedEvent>(ChangeWaveText);
            EventBus.Subscribe<MonsterSpawnedEvent>(SpawnedCurrentMonsterCount);
            EventBus.Subscribe<MonsterDeadEvent>(DeadMonsterCount);

        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<GoldChangedEvent>(ChangeGoldText);
            EventBus.Unsubscribe<WaveStartedEvent>(ChangeWaveText);
            EventBus.Unsubscribe<MonsterSpawnedEvent>(SpawnedCurrentMonsterCount);
            EventBus.Unsubscribe<MonsterDeadEvent>(DeadMonsterCount);
        }

        private void ChangeGoldText(IEvent e)
        {
            GoldChangedEvent evt = (GoldChangedEvent)e;

            goldText.text = evt.Gold.ToString();
        }

        private void ChangeWaveText(IEvent e)
        {
            WaveStartedEvent evt = (WaveStartedEvent)e;

            waveText.text = $"WAVE {evt.Wave.WaveNumber}";
        }

        private void SpawnedCurrentMonsterCount(IEvent e)
        {
            ChangeMonsterCount();
        }

        private void DeadMonsterCount(IEvent e)
        {
            ChangeMonsterCount();
        }


        private void ChangeMonsterCount()
        {
            int count = GameManager.Instance.Spawn.AliveMonsterCount;
            int maxCount = GameConst.MaxMonsterCount;

            float ratio = maxCount > 0 ? Mathf.Clamp01((float)count / maxCount) : 0f;

            fill.localScale = new Vector3(ratio, 1.0f, 1.0f);

            monsterCountText.text = $"{count} / {GameConst.MaxMonsterCount}";
        }


        public void SetTimer(float elapsed)
        {
            timeText.text = FormatTime(elapsed);
        }

        public string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);

            int seconds = Mathf.FloorToInt(time % 60);

            return $"{minutes:00}:{seconds:00}";
        }
    }


}
