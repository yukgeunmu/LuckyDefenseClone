using LuckyDefense.Board;
using LuckyDefense.Heroes;
using UnityEngine;


namespace LuckyDefense.Core.Events
{
    public struct HeroMovedEvent : IEvent
    {
        public Hero Hero { get; set; }
        public GridCell FromCell { get; }
        public GridCell ToCell { get; }

        public HeroMovedEvent( Hero hero, GridCell fromCell, GridCell toCell)
        {
            Hero = hero;
            FromCell = fromCell;
            ToCell = toCell;
        }
    }
}

