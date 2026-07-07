using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;


namespace LuckyDefense.Core.Service
{
    public class HeroMergeService
    {
        private HeroFactory heroFactory;

        private MergeService mergeService;


        public HeroMergeService(MergeService mergeService, HeroFactory heroFactory)
        {
            this.mergeService = mergeService;
            this.heroFactory = heroFactory;
        }

        public bool CanMerge(GridCell cell, out Hero hero)
        {
            hero = null;

            if (cell == null) return false;

            if (cell.Heroes.Count < 3) return false;

            hero = cell.Heroes[0];

            return true;
        }

        public Hero Merge(GridCell cell)
        {
            if (!CanMerge(cell, out var hero))
                return null;

            HeroGrade nextGrade = hero.Data.Grade + 1;

            foreach (var h in cell.Heroes)
            {
                GameManager.Instance.Placement.RemoveHero(h);
            }

            return mergeService.SpawnResultHero(hero.Data, cell.Heroes);

        }
    }
}

