using LuckyDefense.Heroes;
using System.Collections.Generic;

namespace LuckyDefense.Board
{
    public class BoardManager
    {
        public const int Row = 4;
        public const int Col = 5;

        private readonly List<GridCell> cells =
            new();

        public IReadOnlyList<GridCell> Cells => cells;

        public BoardManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            cells.Clear();

            int count = Row * Col;

            for (int i = 0; i < count; i++)
            {
                cells.Add(new GridCell(i));
            }
        }

        public GridCell GetCell(int index)
        {
            if (index < 0 || index >= cells.Count)
                return null;

            return cells[index];
        }

        public GridCell GetEmptyCell()
        {
            foreach (var cell in cells)
            {
                if (cell.IsEmpty)
                    return cell;
            }

            return null;
        }

        public bool PlaceHero(Hero hero)
        {
            GridCell cell = GetEmptyCell();

            if (cell == null)
                return false;

            cell.SetHero(hero);

            return true;
        }

        public bool RemoveHero(Hero hero)
        {
            foreach (var cell in cells)
            {
                if (cell.OccupiedHero == hero)
                {
                    cell.Clear();
                    return true;
                }
            }

            return false;
        }


        public bool PlaceHero(int cellIndex, Hero hero)
        {
            GridCell cell = GetCell(cellIndex);

            if (cell == null)
                return false;

            if (!cell.IsEmpty)
                return false;

            cell.SetHero(hero);

            return true;
        }

        public List<GridCell> FindHeroes(int heroID)
        {
            List<GridCell> result = new();

            foreach (var cell in cells)
            {
                if (cell.IsEmpty)
                    continue;

                if (cell.OccupiedHero.HeroID == heroID)
                {
                    result.Add(cell);
                }
            }

            return result;
        }
    }
}