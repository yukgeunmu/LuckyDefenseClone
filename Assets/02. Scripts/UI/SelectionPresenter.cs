using LuckyDefense.Board;
using LuckyDefense.Board.View;
using LuckyDefense.Core.Events;
using UnityEngine;

namespace LuckyDefense.UI
{
    public class SelectionPresenter : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardView;


        private CellView currentView;

        private void OnEnable()
        {
            EventBus.Subscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Subscribe<CellDeselectedEvent>(OnCellDeselected);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Unsubscribe<CellDeselectedEvent>(OnCellDeselected);
        }

        private void OnCellSelected(IEvent e)
        {
            CellSelectedEvent evt = (CellSelectedEvent)e;

            // 이전 선택 해제
            if (currentView != null)
            {
                currentView.SelectionView.Hide();
            }

            currentView = boardView.GetCellView(evt.Cell.Index);

            if (currentView != null)
            {
                currentView.SelectionView.Show();
            }
        
        }

        private void OnCellDeselected(IEvent e)
        {
            if (currentView == null)
                return;

            currentView.SelectionView.Hide();
            currentView = null;
        }

    }
}