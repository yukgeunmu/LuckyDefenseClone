using LuckyDefense.Heroes.Data;
using LuckyDefense.Monsters.Data;
using LuckyDefense.Skill;
using LuckyDefense.Skill.Data;
using LuckyDefense.Skill.View;
using LuckyDefense.StatusEffects;
using LuckyDefense.StatusEffects.Data;
using LuckyDefense.UI.Data;
using LuckyDefense.Wave.Data;
using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Core.Manager
{
    public class DataManager
    {
        private Dictionary<int, HeroDataSO> heroDict = new();

        private List<HeroDataSO> commonHeroes = new();

        private List<RecipeData> recipes = new();

        public IReadOnlyList<RecipeData> Recipes => recipes;

        private List<SummonInfo> summonInfo = new();

        private Dictionary<int, MonsterData> monsterDict = new();

        private Dictionary<int, WaveData> waveDict = new();

        private Dictionary<StatusEffectType, StatusEffectConfig> statusEffectDict = new();

        private Dictionary<string, AssetReferenceGameObject> uiDict = new();

        public IDictionary<string, AssetReferenceGameObject> UIDct => uiDict;


        public void Init(
            HeroDatabase heroDB,
            RecipeDatabase recipeDB,
            MonsterDatabase monsterDB,
            WaveDatabase waveDB,
            StatusEffectDatabase statusDB,
            HeroSummonTable heroSummonTable,
            UIDatabase uIDatabase
            )
        {
            heroDict.Clear();
            recipes.Clear();

            foreach (HeroDataSO hero in heroDB.Heroes)
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

            foreach (WaveData wave in waveDB.Waves)
            {
                waveDict.Add(
                    wave.WaveNumber,
                    wave);
            }

            foreach (var effect in statusDB.Effects)
            {
                if (statusEffectDict.ContainsKey(effect.Type))
                    continue;

                statusEffectDict.Add(effect.Type, effect);
            }


            foreach (var entry in uIDatabase.entries)
            {
                if (uiDict.ContainsKey(entry.TypeName))
                    continue;

                uiDict.Add(entry.TypeName, entry.Prefab);
            }

            recipes = recipeDB.Recipes;

            summonInfo = heroSummonTable.GradeISummonInfo;

        }

        public HeroDataSO GetHero(int heroID)
        {
            heroDict.TryGetValue(heroID, out HeroDataSO hero);

            return hero;
        }

        public HeroDataSO GetGradeHero(HeroGrade grade)
        {
            List<HeroDataSO> selectedGradeList = new List<HeroDataSO>();

            foreach (var hero in heroDict)
            {
                if (hero.Value.Grade == grade)
                    selectedGradeList.Add(hero.Value);
            }

            int index = UnityEngine.Random.Range(0, selectedGradeList.Count-1);

            return selectedGradeList[index];
        }

        public HeroDataSO GetRandomCommonHero()
        {
            int index =
                UnityEngine.Random.Range(
                    0,
                    commonHeroes.Count);

            return commonHeroes[0];
        }

        public HeroDataSO GetRandomHero()
        {
            HeroGrade grade = GetRandomGrade();

            return GetGradeHero(grade);
        }

        public int GetHeroPrice(HeroGrade heroGrade)
        {

            foreach (var s in summonInfo)
            {
                if(s.Grade == heroGrade)
                {
                    return s.SummonCost;
                }
            }

            return 0;
        }

        public HeroDataSO GetRandomHero(HeroGrade heroGrade)
        {
            return GetGradeHero(heroGrade);
        }


        private HeroGrade GetRandomGrade()
        {
            if (summonInfo == null || summonInfo.Count == 0)
            {
                return HeroGrade.Common;
            }

            float totalProbability = 0f;
            foreach (var rate in summonInfo)
            {
                totalProbability += rate.Probability;
            }


            float randomValue = UnityEngine.Random.Range(0f, totalProbability);

            foreach (var rate in summonInfo)
            {
                if (randomValue < rate.Probability)
                {
                    return rate.Grade;
                }

                randomValue -= rate.Probability;
            }

            return summonInfo[summonInfo.Count - 1].Grade;

        }

        public RecipeData FindRecipe(HeroDataSO heroData)
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
            monsterDict.TryGetValue(id, out MonsterData monster);

            return monster;
        }

        public WaveData GetWave(int wave)
        {
            waveDict.TryGetValue(wave, out WaveData data);

            return data;
        }


        public StatusEffectConfig GetStatusEffect(StatusEffectType type)
        {
            statusEffectDict.TryGetValue(type, out var config);

            return config;
        }

        public AssetReferenceGameObject GetUIAsset<T>()
        {
            string key = typeof(T).Name;

            uiDict.TryGetValue(key, out var asset);

            return asset;
        }
    }
}



