using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using LuckyDefense.UI.Base;
using UnityEngine;


namespace  LuckyDefense.UI.Scene
{
    public class SpawnUI : SceneUI
    {
        [SerializeField] private SpawnBtnPanel commonBtnPanel;
        [SerializeField] private SpawnBtnPanel rareBtnPanel;
        [SerializeField] private SpawnBtnPanel epicBtnPanel;
        [SerializeField] private SpawnBtnPanel legendBtnPanel;


        private void OnEnable()
        {
            commonBtnPanel.SpawnButton.onClick.AddListener(() =>  OnClickHeroSpawn(HeroGrade.Common));
            rareBtnPanel.SpawnButton.onClick.AddListener(() => OnClickHeroSpawn(HeroGrade.Rare));
            epicBtnPanel.SpawnButton.onClick.AddListener(() => OnClickHeroSpawn(HeroGrade.Epic));
            legendBtnPanel.SpawnButton.onClick.AddListener(() => OnClickHeroSpawn(HeroGrade.Legendary));
        }


        private void OnDisable()
        {
            commonBtnPanel.SpawnButton.onClick.RemoveListener(() => OnClickHeroSpawn(HeroGrade.Common));
            rareBtnPanel.SpawnButton.onClick.RemoveListener(() => OnClickHeroSpawn(HeroGrade.Rare));
            epicBtnPanel.SpawnButton.onClick.RemoveListener(() => OnClickHeroSpawn(HeroGrade.Epic));
            legendBtnPanel.SpawnButton.onClick.RemoveListener(() => OnClickHeroSpawn(HeroGrade.Legendary));
        }


        private void OnClickHeroSpawn(HeroGrade grade)
        {
            GameManager.Instance.Spawn.SummonHero(grade);
        }
    }
}

