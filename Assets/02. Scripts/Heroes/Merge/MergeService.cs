using LuckyDefense.Board;
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using System.Collections.Generic;
using static Unity.VisualScripting.Member;

namespace LuckyDefense.Heroes.Merge
{
    public class MergeService
    {

        private HeroFactory heroFactory;

        public MergeService(HeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
        }


        public bool TryMerge(Hero source, Hero target)
        {
            if (source == null)
                return false;

            if (target == null)
                return false;

            if (source.HeroID != target.HeroID)
            {
                return false;
            }

            BoardManager board = GameManager.Instance.Board;

            List<Hero> consumedHeroes = new();

            return true;

        }


        public bool TryMerge(int heroID)
        {
            BoardManager board = GameManager.Instance.Board;

            List<GridCell> heroes = board.FindHeroes(heroID);

            List<Hero> consumedHeroes = new();

            for (int i = 0; i < 3; i++)
            {
                consumedHeroes.Add(
                    heroes[i].OccupiedHero);
            }

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

            int targetIndex = heroes[0].Index;

            for (int i = 0; i < 3; i++)
            {
                heroes[i].Clear();
            }

            Hero mergedHero = heroFactory.Create(recipe.ResultHero);

            board.PlaceHero(targetIndex, mergedHero);

            EventBus.Publish(new HeroMergedEvent(mergedHero, consumedHeroes));

            return true;
        }
    }
}