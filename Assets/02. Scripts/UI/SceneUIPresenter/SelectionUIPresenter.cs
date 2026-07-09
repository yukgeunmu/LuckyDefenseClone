using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.UI.Popup;
using UnityEngine;

namespace LuckyDefense.UI.Scene
{
    public class SelectionUIPresenter : MonoBehaviour
    {
        [SerializeField]
        private SelectionUI selectionUI;


        private void Start()
        {
            GameManager.Instance.UI.Register(selectionUI);
        }

        private void OnEnable()
        {
            EventBus.Subscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Subscribe<CellDeselectedEvent>(OnCellDeselected);

            selectionUI.MergeButton.onClick.AddListener(OnMergeClicked);
            selectionUI.SellButton.onClick.AddListener(OnSellClicked);
            selectionUI.RecipeButton.onClick.AddListener(OnClickRecipe);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Unsubscribe<CellDeselectedEvent>(OnCellDeselected);

            selectionUI.MergeButton.onClick.RemoveListener(OnMergeClicked);
            selectionUI.SellButton.onClick.RemoveListener(OnSellClicked);
            selectionUI.RecipeButton.onClick.RemoveListener(OnClickRecipe);

        }

        private void OnCellSelected(IEvent e)
        {
            CellSelectedEvent evt = (CellSelectedEvent)e;

            GridCell cell = evt.Cell;

            if (cell == null || cell.HeroCount == 0)
            {
                selectionUI.Hide();
                return;
            }

            Hero hero = cell.Heroes[0];

            bool canMerge = GameManager.Instance.Merge.HeroMergeService.CanMerge(cell);
            bool canSell = GameManager.Instance.HeroSell.CanSell(cell);

            selectionUI.Show();

            selectionUI.RefreshHero(hero);

            selectionUI.SetMergeVisible(canMerge);

            selectionUI.SetSellVisible(canSell);
        }

        private void OnCellDeselected(IEvent e)
        {
            selectionUI.Hide();
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
            GameManager.Instance.UI.Open<RecipePopup>();
        }
    }
}