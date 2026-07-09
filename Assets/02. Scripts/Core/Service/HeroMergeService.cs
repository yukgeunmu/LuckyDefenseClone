using LuckyDefense.Board;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;


namespace LuckyDefense.Core.Service
{
    public class HeroMergeService
    {

        private MergeService mergeService;

        public HeroMergeService(MergeService mergeService)
        {
            this.mergeService = mergeService;
        }

        public bool CanMerge(GridCell cell)
        {

            if (cell == null) return false;

            if (cell.Heroes.Count < 3) return false;

            return true;
        }

        public Hero Merge(GridCell cell)
        {
            if (!CanMerge(cell))
                return null;

            Hero hero = cell.Heroes[0];

            HeroGrade nextGrade = hero.Data.Grade + 1;

            List<Hero> consumeHeroes = cell.GetHeroes();

            foreach (Hero h in consumeHeroes)
            {
                GameManager.Instance.Placement.RemoveHero(h);

                GameManager.Instance.HeroCombat.Remove(h);
            }

            HeroData heroData = GameManager.Instance.Data.GetRandomHero(nextGrade);

            return mergeService.SpawnResultHero(heroData, consumeHeroes);

        }
    }
}

