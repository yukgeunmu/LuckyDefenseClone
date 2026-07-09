using LuckyDefense.Heroes;
using LuckyDefense.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI.Scene
{
    public class SelectionUI : SceneUI
    {
        [SerializeField]
        private HeroInfoPanel heroInfoPanel;

        [Header("Buttons")]
        [SerializeField] private Button mergeButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Button recipeButton;

        public Button MergeButton => mergeButton;
        public Button SellButton => sellButton;

        public Button RecipeButton => recipeButton;

        public override void Initialize()
        {
            Hide();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public void RefreshHero(Hero hero)
        {
            heroInfoPanel.Refresh(hero);
        }


        public void SetMergeVisible(bool value)
        {
            mergeButton.gameObject.SetActive(value);
        }

        public void SetSellVisible(bool value)
        {
            sellButton.gameObject.SetActive(value);
        }
    }
}