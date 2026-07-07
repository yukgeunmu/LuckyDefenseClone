using LuckyDefense.Board;

namespace LuckyDefense.Core.Events
{
    public class CellSelectedEvent : IEvent
    {
        public GridCell Cell { get; }

        public CellSelectedEvent(GridCell cell)
        {
            Cell = cell;
        }
    }
}
