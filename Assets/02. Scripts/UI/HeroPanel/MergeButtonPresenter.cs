using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Factory;
using UnityEngine;

namespace LuckyDefense.UI.HeroPanel
{
    public class MergeButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private MergeButtonView view;

        private void OnEnable()
        {
            EventBus.Subscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Subscribe<CellDeselectedEvent>(OnCellDeselected);

            view.Button.onClick.AddListener(OnMergeClicked);

            view.Hide();
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Unsubscribe<CellDeselectedEvent>(OnCellDeselected);

            view.Button.onClick.RemoveListener(OnMergeClicked);
        }

        private void OnCellSelected(IEvent e)
        {

            GridCell cell = GameManager.Instance.CellSelection.SelectedCell;
            bool canMerge = GameManager.Instance.Merge.HeroMergeService.CanMerge(cell, out Hero hero);

            if (!canMerge)
            {
                view.Hide();
                return;
            }

            view.Show();
            view.SetInteractable(canMerge);
        }

        private void OnCellDeselected(IEvent e)
        {
            view.Hide();
        }

        private void OnMergeClicked()
        {
            GridCell cell = GameManager.Instance.CellSelection.SelectedCell;

            if (cell == null)
                return;

            Hero hero  = GameManager.Instance.Merge.HeroMergeService.Merge(cell);

            if (hero == null)
                return;

            GameManager.Instance.CellSelection.Select(hero.CurrentCell);
        }
    }
}