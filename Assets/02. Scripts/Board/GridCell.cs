using LuckyDefense.Heroes;

namespace LuckyDefense.Board
{
    public class GridCell
    {
        public int Index { get; }

        public Hero OccupiedHero { get; private set; }

        public bool IsEmpty => OccupiedHero == null;

        public GridCell(int index)
        {
            Index = index;
        }

        public void SetHero(Hero hero)
        {
            OccupiedHero = hero;
        }

        public void Clear()
        {
            OccupiedHero = null;
        }
    }
}