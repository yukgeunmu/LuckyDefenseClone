using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core.Manager
{
    public class BoardManager
    {
        public const int Row = 5;
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
            GridCell firstEmptyCell = null;

            foreach (var cell in cells)
            {

                if (cell.HeroData == heroData && !cell.IsFull)
                    return cell;

                if (cell.IsEmpty && firstEmptyCell == null)
                    firstEmptyCell = cell;
            }

            return firstEmptyCell;
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

        public void OptimizeHeroStacks()
        {
            Dictionary<HeroData, List<GridCell>> groups = new();

            foreach (GridCell cell in cells)
            {
                if (cell.HeroCount == 0)
                    continue;

                HeroData data = cell.Heroes[0].Data;

                if (!groups.TryGetValue(data, out var list))
                {
                    list = new List<GridCell>();
                    groups.Add(data, list);
                }

                list.Add(cell);
            }

            foreach (var pair in groups)
            {
                OptimizeGroup(pair.Value);
            }
        }

        private void OptimizeGroup(List<GridCell> cells)
        {
            if (cells.Count <= 1)
                return;

            cells.Sort((a, b) => a.Index.CompareTo(b.Index));

            for (int i = 0; i < cells.Count; i++)
            {
                GridCell target = cells[i];

                while (target.HeroCount < GameConst.MaxHeroStack)
                {
                    GridCell source = FindSourceCell(cells, i);

                    if (source == null)
                        return;

                    Hero hero = source.Heroes[source.HeroCount - 1];

                    source.RemoveHero(hero);

                    target.AddHero(hero);

                    EventBus.Publish(new HeroMovedEvent(hero, source, target));
                }
            }
        }

        private GridCell FindSourceCell(List<GridCell> cells, int targetIndex)
        {
            for (int i = cells.Count - 1; i > targetIndex; i--)
            {
                GridCell cell = cells[i];

                if (cell.HeroCount > 0)
                    return cell;
            }

            return null;
        }

    }
}