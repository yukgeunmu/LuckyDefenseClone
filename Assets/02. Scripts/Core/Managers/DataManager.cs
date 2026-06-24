using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core.Manager
{
    public class DataManager
    {
        private Dictionary<int, HeroData> heroDict = new();

        private List<HeroData> commonHeroes = new();

        private List<RecipeData> recipes = new();

        public void Init(HeroDatabase database, RecipeDatabase recipeDatabase)
        {
            heroDict.Clear();
            recipes.Clear();

            foreach (HeroData hero in database.Heroes)
            {
                if (heroDict.ContainsKey(hero.HeroID))
                {
                    UnityEngine.Debug.LogError(
                        $"ม฿บน HeroID : {hero.HeroID}");

                    continue;
                }

                heroDict.Add(hero.HeroID, hero);

                if (hero.Grade == HeroGrade.Common)
                    commonHeroes.Add(hero);
            }

            recipes = recipeDatabase.Recipes;

        }

        public HeroData GetHero(int heroID)
        {
            heroDict.TryGetValue(heroID, out HeroData hero);

            return hero;
        }

        public HeroData GetRandomCommonHero()
        {
            int index =
                UnityEngine.Random.Range(
                    0,
                    commonHeroes.Count);

            return commonHeroes[index];
        }

        public RecipeData FindRecipe(HeroData heroData)
        {
            foreach (var recipe in recipes)
            {
                if (recipe.Materials.Count != 1)
                    continue;

                RecipeMaterial material =
                    recipe.Materials[0];

                if (material.HeroData == heroData
                    && material.Count == 3)
                {
                    return recipe;
                }
            }

            return null;
        }
    }
}



