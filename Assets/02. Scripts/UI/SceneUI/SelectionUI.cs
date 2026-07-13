using Cysharp.Threading.Tasks;
using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.UI.Base;
using LuckyDefense.UI.Popup;
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



        private void OnEnable()
        {
            MergeButton.onClick.AddListener(OnMergeClicked);
            SellButton.onClick.AddListener(OnSellClicked);
            RecipeButton.onClick.AddListener(OnClickRecipe);
        }

        private void OnDisable()
        {
            MergeButton.onClick.RemoveListener(OnMergeClicked);
            SellButton.onClick.RemoveListener(OnSellClicked);
            RecipeButton.onClick.RemoveListener(OnClickRecipe);

        }
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


        private void OnMergeClicked()
        {
            GridCell cell = GameManager.Instance.CellSelection.SelectedCell;

            if (cell == null)
                return;

            Hero hero = GameManager.Instance.Merge.HeroMergeService.Merge(cell);

            if (hero == null)
                return;

            GameManager.Instance.CellSelection.Select(hero.CurrentCell);
        }

        private void OnSellClicked()
        {
            GridCell cell = GameManager.Instance.CellSelection.SelectedCell;

            if (cell == null)
                return;

            GameManager.Instance.HeroSell.Sell(cell);

            GameManager.Instance.CellSelection.Deselect();
        }

        private void OnClickRecipe()
        {
            GameManager.Instance.UI.Open<RecipePopupUI>().Forget();
        }

    }
}