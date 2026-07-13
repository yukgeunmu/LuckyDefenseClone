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
        private Dictionary<int, HeroData> heroDict = new();

        private List<HeroData> commonHeroes = new();

        private List<RecipeData> recipes = new();

        public IReadOnlyList<RecipeData> Recipes => recipes;

        private List<SummonRate> summonRates = new();

        private Dictionary<int, MonsterData> monsterDict = new();

        private Dictionary<int, WaveData> waveDict = new();

        private Dictionary<SkillEffectType, SkillEffectData> skillEffects = new();

        private Dictionary<StatusEffectType, StatusEffectConfig> statusEffectDict = new();

        private Dictionary<ProjectileType, ProjectileConfig> skillProjectileDict = new();

        private Dictionary<string, AssetReferenceGameObject> uiDict = new();

        public  IDictionary<ProjectileType, ProjectileConfig> ProjectileDict => skillProjectileDict;

        public IDictionary<string, AssetReferenceGameObject> UIDct => uiDict;


        public void Init(
            HeroDatabase heroDB,
            RecipeDatabase recipeDB,
            MonsterDatabase monsterDB,
            WaveDatabase waveDB,
            SkillEffectDatabase skillEffectDB,
            StatusEffectDatabase statusDB,
            SkillProjectileDatabase skillProjectileDB,
            HeroSummonTable heroSummonTable,
            UIDatabase uIDatabase
            )
        {
            heroDict.Clear();
            recipes.Clear();
            skillEffects.Clear();

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

            foreach (WaveData wave in waveDB.Waves)
            {
                waveDict.Add(
                    wave.WaveNumber,
                    wave);
            }

            foreach (var effect in skillEffectDB.Effects)
            {
                skillEffects.Add(
                    effect.Type,
                    effect);
            }

            foreach (var effect in statusDB.Effects)
            {
                if (statusEffectDict.ContainsKey(effect.Type))
                    continue;

                statusEffectDict.Add(effect.Type, effect);
            }

            foreach (var projectile in skillProjectileDB.SkillProjectileConfigs)
            {
                if (skillProjectileDict.ContainsKey(projectile.Type))
                    continue;

                skillProjectileDict.Add(projectile.Type, projectile);
            }

            foreach (var entry in uIDatabase.entries)
            {
                if (uiDict.ContainsKey(entry.TypeName))
                    continue;

                uiDict.Add(entry.TypeName, entry.Prefab);
            }

            recipes = recipeDB.Recipes;

            summonRates = heroSummonTable.Rates;

        }

        public HeroData GetHero(int heroID)
        {
            heroDict.TryGetValue(heroID, out HeroData hero);

            return hero;
        }

        public HeroData GetGradeHero(HeroGrade grade)
        {
            List<HeroData> selectedGradeList = new List<HeroData>();

            foreach (var hero in heroDict)
            {
                if (hero.Value.Grade == grade)
                    selectedGradeList.Add(hero.Value);
            }

            int index = UnityEngine.Random.Range(0, selectedGradeList.Count);

            return selectedGradeList[index];
        }

        public HeroData GetRandomCommonHero()
        {
            int index =
                UnityEngine.Random.Range(
                    0,
                    commonHeroes.Count);

            return commonHeroes[0];
        }

        public HeroData GetRandomHero()
        {
            HeroGrade grade = GetRandomGrade();

            return GetGradeHero(grade);
        }

        public HeroData GetRandomHero(HeroGrade heroGrade)
        {
            return GetGradeHero(heroGrade);
        }


        private HeroGrade GetRandomGrade()
        {
            if (summonRates == null || summonRates.Count == 0)
            {
                return HeroGrade.Common;
            }

            float totalProbability = 0f;
            foreach (var rate in summonRates)
            {
                totalProbability += rate.Probability;
            }


            float randomValue = UnityEngine.Random.Range(0f, totalProbability);

            foreach (var rate in summonRates)
            {
                if (randomValue < rate.Probability)
                {
                    return rate.Grade;
                }

                randomValue -= rate.Probability;
            }

            return summonRates[summonRates.Count - 1].Grade;

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
            monsterDict.TryGetValue(id, out MonsterData monster);

            return monster;
        }

        public WaveData GetWave(int wave)
        {
            waveDict.TryGetValue(wave, out WaveData data);

            return data;
        }

        public SkillEffectData GetSkillEffect(SkillEffectType type)
        {
            skillEffects.TryGetValue(type, out var effect);

            return effect;
        }

        public StatusEffectConfig GetStatusEffect(StatusEffectType type)
        {
            statusEffectDict.TryGetValue(type, out var config);

            return config;
        }

        public ProjectileConfig GetProjectile(ProjectileType type)
        {
            skillProjectileDict.TryGetValue(type, out var projectile);

            return projectile;
        }

        public AssetReferenceGameObject GetUIAsset<T>()
        {
            string key = typeof(T).Name;

            uiDict.TryGetValue(key, out var asset);

            return asset;
        }
    }
}



