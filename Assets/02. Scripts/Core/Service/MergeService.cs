using LuckyDefense.Board;
using LuckyDefense.Heroes;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using System.Collections.Generic;

namespace LuckyDefense.Core.Service
{
    public class MergeService
    {

        private HeroFactory heroFactory;

        public MergeService(HeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
        }


        public bool CanMerge(GridCell cell)
        {
            if (cell.HeroCount < 3)
                return false;

            Hero firstHero = cell.Heroes[0];

            foreach (Hero hero in cell.Heroes)
            {
                if (hero.HeroID != firstHero.HeroID)
                    return false;
            }

            return true;
        }

        public bool TryMerge(GridCell cell)
        {
            if (!CanMerge(cell))
                return false;

            Hero sourceHero =
                cell.Heroes[0];

            RecipeData recipe =
                GameManager.Instance.Data
                    .FindRecipe(sourceHero.Data);

            if (recipe == null)
                return false;

            List<Hero> consumedHeroes = new(cell.Heroes);

            foreach (Hero hero in consumedHeroes)
            {
                GameManager.Instance.Placement
                    .RemoveHero(hero);
            }

            Hero mergedHero = heroFactory.Create(recipe.ResultHero);

            GameManager.Instance.Placement
                .PlaceMergeHero(cell.Index, mergedHero);

            EventBus.Publish( new HeroMergedEvent(mergedHero, consumedHeroes));

            return true;
        }




        //public bool TryMerge(int heroID)
        //{
        //    BoardManager board = GameManager.Instance.Board;

        //    List<GridCell> heroes = board.FindHeroes(heroID);

        //    List<Hero> consumedHeroes = new();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        consumedHeroes.Add(
        //            heroes[i].OccupiedHero);
        //    }

        //    if (heroes.Count < 3)
        //        return false;

        //    HeroData sourceHero =
        //        heroes[0]
        //            .OccupiedHero
        //            .Data;

        //    RecipeData recipe =
        //        GameManager.Instance.Data
        //            .FindRecipe(sourceHero);

        //    if (recipe == null)
        //        return false;

        //    int targetIndex = heroes[0].Index;

        //    for (int i = 0; i < 3; i++)
        //    {
        //        heroes[i].Clear();
        //    }

        //    Hero mergedHero = heroFactory.Create(recipe.ResultHero);

        //    board.PlaceHero(targetIndex, mergedHero);

        //    EventBus.Publish(new HeroMergedEvent(mergedHero, consumedHeroes));

        //    return true;
        //}
    }
}