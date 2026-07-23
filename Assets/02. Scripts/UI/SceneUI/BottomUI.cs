using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using LuckyDefense.UI.Base;
using UnityEngine;


namespace  LuckyDefense.UI.Scene
{
    public class BottomUI : SceneUI
    {
        [SerializeField] private SpawnBtnPanel spawnBtnPanel;


        private void OnEnable()
        {
            spawnBtnPanel.SpawnButton.onClick.AddListener(OnClickHeroSpawn);
        }


        private void OnDisable()
        {

        }


        private void OnClickHeroSpawn()
        {
            HeroDataSO hero = GameManager.Instance.Data.GetRandomHero();

            GameManager.Instance.Spawn.SummonHero(hero.Grade);
        }
    }
}

