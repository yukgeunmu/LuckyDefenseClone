using LuckyDefense.Board;
using LuckyDefense.Heroes;
using LuckyDefense.Core.Events;
using UnityEngine;



namespace LuckyDefense.Core.Service
{
    public class CellSelectionService
    {
        public GridCell SelectedCell { get; private set; }

        public Hero SelectedHero
        {
            get
            {
                if (SelectedCell == null)
                    return null;

                if (SelectedCell.Heroes.Count == 0)
                    return null;

                return SelectedCell.Heroes[0];
            }
        }

        public void Select(GridCell cell)
        {
            if (SelectedCell == cell)
            {
                Deselect();
                return;
            }

            SelectedCell = cell;

            EventBus.Publish(new CellSelectedEvent(cell));
        }

        public void Deselect()
        {
            if (SelectedCell == null)
                return;

            SelectedCell = null;

            EventBus.Publish(new CellDeselectedEvent());
        }
    }
}

