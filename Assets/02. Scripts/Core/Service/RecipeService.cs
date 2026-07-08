using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using System.Collections.Generic;


namespace LuckyDefense.Core.Service
{
    public class RecipeService
    {
        private MergeService mergeService;

        public RecipeService(MergeService mergeService)
        {
            this.mergeService = mergeService;
        }


        public Hero Merge(RecipeData recipe)
        {
            if (recipe == null)
                return null;


            List<Hero> heroes = GameManager.Instance.Placement.GetAllHeroes();


            if (!IsMatched(heroes, recipe.Materials))
                return null;


            List<Hero> consumes = FindConsumeHeroes(heroes, recipe.Materials);

            if (consumes == null)
                return null;


            foreach (var hero in consumes)
            {
                GameManager.Instance.Placement.RemoveHero(hero);
            }

            return mergeService.SpawnResultHero(recipe.ResultHero, consumes);
        }

        public List<RecipeData> GetAvailableRecipes()
        {
            List<RecipeData> result = new();

            List<Hero> heroes = GameManager.Instance.Placement.GetAllHeroes();

            foreach (var recipe in GameManager.Instance.Data.Recipes)
            {
                if (IsMatched(heroes, recipe.Materials))
                {
                    result.Add(recipe);
                }
            }

            return result;
        }

        public bool IsMatched(List<Hero> heroes, List<RecipeMaterial> materials)
        {
            if (heroes == null || materials == null)
                return false;

            Dictionary<HeroData, int> heroCounts = new();

            foreach (Hero hero in heroes)
            {
                if (hero == null || hero.Data == null)
                    continue;

                heroCounts.TryGetValue(hero.Data, out int count);
                heroCounts[hero.Data] = count + 1;
            }

            foreach (RecipeMaterial material in materials)
            {
                if (material == null || material.HeroData == null)
                    continue;

                if (!heroCounts.TryGetValue(material.HeroData, out int count))
                    return false;

                if (count < material.Count)
                    return false;
            }

            return true;
        }

        private List<Hero> FindConsumeHeroes(List<Hero> heroes, List<RecipeMaterial> materials)
        {
            List<Hero> result = new();

            foreach (RecipeMaterial material in materials)
            {
                int count = 0;

                foreach (Hero hero in heroes)
                {
                    if (hero.Data != material.HeroData)
                        continue;

                    if (result.Contains(hero))
                        continue;

                    result.Add(hero);

                    count++;

                    if (count >= material.Count)
                        break;
                }

                if (count < material.Count)
                    return null;
            }

            return result;
        }


    }
}

