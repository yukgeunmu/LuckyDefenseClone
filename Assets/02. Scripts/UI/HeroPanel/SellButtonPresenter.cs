using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.UI.HeroPanel
{
    public class SellButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private SellButtonView view;

        private void OnEnable()
        {
            EventBus.Subscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Subscribe<CellDeselectedEvent>(OnCellDeselected);

            view.Button.onClick.AddListener(OnSellClicked);

            view.Hide();
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Unsubscribe<CellDeselectedEvent>(OnCellDeselected);

            view.Button.onClick.RemoveListener(OnSellClicked);
        }

        private void OnCellSelected(IEvent e)
        {
            GridCell cell =
                GameManager.Instance
                    .CellSelection
                    .SelectedCell;

            if (cell == null || cell.HeroCount == 0)
            {
                view.Hide();
                return;
            }

            bool canSell =
                GameManager.Instance
                    .HeroSell
                    .CanSell(cell);

            view.Show();
            view.SetInteractable(canSell);
        }

        private void OnCellDeselected(IEvent e)
        {
            view.Hide();
        }

        private void OnSellClicked()
        {
            GridCell cell =
                GameManager.Instance
                    .CellSelection
                    .SelectedCell;

            if (cell == null)
                return;

            GameManager.Instance
                .HeroSell
                .Sell(cell);

            GameManager.Instance
                .CellSelection
                .Deselect();
        }
    }
}