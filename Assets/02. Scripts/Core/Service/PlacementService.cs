using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;


namespace LuckyDefense.Core.Service
{
    public class PlacementService
    {
        private readonly BoardManager board;

        public PlacementService(BoardManager board)
        {
            this.board = board;
        }

        public bool PlaceHero(Hero hero)
        {
            GridCell cell = board.GetAvailableCell(hero.Data);

            if (cell == null)
                return false;

            cell.AddHero(hero);
            hero.CurrentCell = cell;

            return true;
        }

        public bool MoveStack(GridCell source, GridCell target)
        {
            if (source == null || target == null)
                return false;

            if (source.IsEmpty)
                return false;

            if (!target.IsEmpty)
                return false;

            foreach (Hero hero in source.Heroes)
            {
                target.AddHero(hero);
                hero.CurrentCell = target;
            }

            source.Clear();

            EventBus.Publish(new CellMovedEvent(source, target));

            return true;
        }

        public bool RemoveHero(Hero hero)
        {
            GridCell cell = hero.CurrentCell;

            if (cell == null)
                return false;

            bool result = cell.RemoveHero(hero);

            if (result)
                hero.CurrentCell = null;

            return result;
        }
    }
}
