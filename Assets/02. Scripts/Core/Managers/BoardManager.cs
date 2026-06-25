using LuckyDefense.Board;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core.Manager
{
    public class BoardManager
    {
        public const int Row = 4;
        public const int Col = 5;

        private readonly List<GridCell> cells = new();

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

        public GridCell GetAvailableCell(HeroData heroData)
        {
            foreach (var cell in cells)
            {
                if (cell.IsEmpty)
                    return cell;

                if (cell.HeroData == heroData && !cell.IsFull)
                    return cell;
            }

            return null;
        }


        public bool PlaceHero(int cellIndex, Hero hero)
        {
            GridCell cell = GetCell(cellIndex);

            if (cell == null)
                return false;

            if (!cell.AddHero(hero))
                return false;

            hero.CurrentCell = cell;

            return true;
        }



        public bool PlaceHero(Hero hero)
        {
            GridCell cell = GetAvailableCell(hero.Data);

            if (cell == null)
                return false;

            cell.AddHero(hero);
            hero.CurrentCell = cell;

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


        //public List<GridCell> FindHeroes(int heroID)
        //{
        //    List<GridCell> result = new();

        //    foreach (var cell in cells)
        //    {
        //        if (cell.IsEmpty)
        //            continue;

        //        if (cell.OccupiedHero.HeroID == heroID)
        //        {
        //            result.Add(cell);
        //        }
        //    }

        //    return result;
        //}

        public GridCell FindCell(Hero hero)
        {


            foreach (var cell in cells)
            {
                if (cell.Contains(hero))
                {
                    return cell;
                }

            }

            return null;
        }

        public bool MoveCell(GridCell source, GridCell target)
        {
            if (!target.IsEmpty)
                return false;

            foreach (var hero in source.Heroes)
            {
                target.AddHero(hero);
            }

            source.Clear();

            return true;
        }
    }
}