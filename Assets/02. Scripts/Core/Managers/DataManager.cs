using LuckyDefense.Heroes.Data;
using LuckyDefense.Monster.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core.Manager
{
    public class DataManager
    {
        private Dictionary<int, HeroData> heroDict = new();

        private List<HeroData> commonHeroes = new();

        private List<RecipeData> recipes = new();

        private Dictionary<int, MonsterData> monsterDict = new();

        public void Init(HeroDatabase heroDB, RecipeDatabase recipeDatabase, MonsterDatabase monsterDB)
        {
            heroDict.Clear();
            recipes.Clear();

            foreach (HeroData hero in heroDB.Heroes)
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

            foreach (var monster in monsterDB.Monsters)
            {
                monsterDict.Add(
                    monster.MonsterID,
                    monster);
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

        public MonsterData GetMonster(int id)
        {
            monsterDict.TryGetValue(
                id,
                out MonsterData monster);

            return monster;
        }
    }
}



