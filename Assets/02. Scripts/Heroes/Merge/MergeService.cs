using LuckyDefense.Board;
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using System.Collections.Generic;

namespace LuckyDefense.Heroes.Merge
{
    public class MergeService
    {

        private HeroFactory heroFactory;

        public MergeService(HeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
        }

        public bool TryMerge(int heroID)
        {
            BoardManager board =
                GameManager.Instance.Board;

            List<GridCell> heroes =
                board.FindHeroes(heroID);

            if (heroes.Count < 3)
                return false;

            HeroData sourceHero =
                heroes[0]
                    .OccupiedHero
                    .Data;

            RecipeData recipe =
                GameManager.Instance.Data
                    .FindRecipe(sourceHero);

            if (recipe == null)
                return false;

            int targetIndex =
                heroes[0].Index;

            for (int i = 0; i < 3; i++)
            {
                heroes[i].Clear();
            }

            Hero mergedHero =
                heroFactory.Create(
                    recipe.ResultHero);

            board.PlaceHero(
                targetIndex,
                mergedHero);

            EventBus.Publish(
                new HeroMergedEvent(
                    mergedHero));

            return true;
        }
    }
}