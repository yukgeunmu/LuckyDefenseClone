using LuckyDefense.Board;
using LuckyDefense.Core;

namespace LuckyDefense.Core.Events
{
    public struct CellMovedEvent : IEvent
    {
        public GridCell SourceCell;
        public GridCell TargetCell;

        public CellMovedEvent(GridCell sourceCell,GridCell targetCell)
        {
            SourceCell = sourceCell;
            TargetCell = targetCell;
        }
    }
}