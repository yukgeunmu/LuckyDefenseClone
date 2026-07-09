using LuckyDefense.Board;
using LuckyDefense.Heroes;

namespace LuckyDefense.Core.Events
{
    public struct HeroRemovedEvent : IEvent
    {
        public Hero Hero { get; }

        public GridCell Cell { get; }

        public HeroRemovedEvent(Hero hero, GridCell cell)
        {
            Hero = hero;
            Cell = cell;
        }
    }
}