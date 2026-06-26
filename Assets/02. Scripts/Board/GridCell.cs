using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Board
{
    public class GridCell
    {
        public const int MaxHeroCount = 3;
        public int Index { get; }
        private readonly List<Hero> heroes = new();
        public IReadOnlyList<Hero> Heroes => heroes;
        public bool IsEmpty => heroes.Count == 0;
        public bool IsFull => heroes.Count >= MaxHeroCount;
        public int HeroCount => heroes.Count;

        public GridCell CurrentCell
        {
            get;
            internal set;
        }

        public HeroData HeroData
        {
            get
            {
                if (heroes.Count == 0)
                    return null;

                return heroes[0].Data;
            }
        }
        public GridCell(int index)
        {
            Index = index;
        }

        public bool AddHero(Hero hero)
        {
            if (IsFull)
                return false;

            if (!IsEmpty)
            {
                if (HeroData != hero.Data)
                    return false;
            }

            heroes.Add(hero);

            hero.CurrentCell = this;

            return true;
        }

        public bool RemoveHero(Hero hero)
        {
            return heroes.Remove(hero);
        }


        public bool Contains(Hero hero)
        {
            return heroes.Contains(hero);
        }


        public void Clear()
        {
            heroes.Clear();
        }

        public bool CanMoveTo(GridCell target)
        {
            return target.IsEmpty;
        }

        public List<Hero> GetHeroes()
        {
            return new List<Hero>(heroes);
        }
    }
}