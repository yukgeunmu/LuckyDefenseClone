using LuckyDefense.Board;

namespace LuckyDefense.Core.Events
{
    public struct CellSelectedEvent : IEvent
    {
        public GridCell Cell { get; }

        public CellSelectedEvent(GridCell cell)
        {
            Cell = cell;
        }
    }
}
