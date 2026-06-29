using LuckyDefense.Board;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;
using System.Diagnostics;

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
            {
                UnityEngine.Debug.Log(index);
                return null;
            }


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

    }
}