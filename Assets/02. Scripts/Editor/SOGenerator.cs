using LuckyDefense.Core;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Monsters.Data;
using LuckyDefense.SheetData;
using LuckyDefense.Skill.Data;
using LuckyDefense.Wave.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class SOGenerator
{
    private static Dictionary<int, SkillDataSO> skillCache;
    private static Dictionary<int, HeroDataSO> heroCache;
    private static Dictionary<int, MonsterDataSO> monsterCache;

    private static Dictionary<int, List<RecipeMaterial>> materialCache;

    public static void Initialize()
    {
        skillCache = BuildCache<SkillDataSO>();
        heroCache = BuildCache<HeroDataSO>();
        monsterCache = BuildCache<MonsterDataSO>();

        BuildRecipeMaterialCache();
    }


    public static void Preprocessing<TSO, TD>(string json, string savePath) where TSO : ScriptableObject
    {
        var list = JsonConvert.DeserializeObject<List<TD>>(json);

        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);


        foreach (var dto in list)
        {
            string fileName = GetFileName(dto);
            string path = $"{savePath}/{fileName}.asset";

            TSO asset = AssetDatabase.LoadAssetAtPath<TSO>(path);

            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<TSO>();
                AssetDatabase.CreateAsset(asset, path );
            }

            CopyFields(dto, asset);
            EditorUtility.SetDirty(asset);

            //var asset = ScriptableObject.CreateInstance<TSO>();

            //CopyFields(dto, asset);

            //string fileName = GetFileName(dto);
            //string path = $"{savePath}/{fileName}.asset";

            //TSO existing = AssetDatabase.LoadAssetAtPath<TSO>(path);

            //if (existing != null)
            //{
            //    CopyFields(dto, existing);
            //    EditorUtility.SetDirty(existing);
            //}
            //else
            //{
            //    AssetDatabase.CreateAsset(asset, path);
            //}

        }

    }


    public static void ResolveAllReference<TSO, TD>(string json, string savePath) where TSO : ScriptableObject
    {
        var list = JsonConvert.DeserializeObject<List<TD>>(json);

        foreach (var dto in list)
        {
            string fileName = GetFileName(dto);
            string path = $"{savePath}/{fileName}.asset";

            TSO asset = AssetDatabase.LoadAssetAtPath<TSO>(path);

            if (asset == null)
            {
                Debug.LogWarning($"SO를 찾을 수 없습니다 : {path}");
                continue;
            }

            ResolveReference(dto, asset);

            EditorUtility.SetDirty(asset);
        }
    }

    static void CopyFields<TD, TSO>(TD source, TSO target)
    {
        var soFields = typeof(TSO)
            .GetFields()
            .ToDictionary(f => f.Name);

        foreach (var dtoField in typeof(TD).GetFields())
        {
            if (!soFields.TryGetValue(dtoField.Name, out var soField))
                continue;

            if (dtoField.FieldType != soField.FieldType)
                continue;

            soField.SetValue(target, dtoField.GetValue(source));
        }
    }

    static string GetFileName<TD>(TD dto)
    {
        Type type = typeof(TD);

        var idField =
            type.GetField("RecipeID") ??
            type.GetField("HeroID") ??
            type.GetField("MonsterID") ??
            type.GetField("SkillID") ??
            type.GetField("ID");

        if (idField == null)
            return Guid.NewGuid().ToString();

        string className = type.Name.Replace("Data", "").ToUpper();

        return $"{className}{idField.GetValue(dto)}";
    }

    static void ResolveReference<TD, TSO>(TD dto, TSO so)
    {
        if (dto is HeroData heroDto &&
            so is HeroDataSO heroSO)
        {
            heroSO.PassiveSkills.Clear();

            foreach (int id in heroDto.PassiveSkillIDs)
            {
                if (skillCache.TryGetValue(id, out var skill))
                {
                    heroSO.PassiveSkills.Add(skill);
                }
            }

            heroSO.ActiveSkills.Clear();

            foreach (int id in heroDto.ActiveSkillIDs)
            {
                if (skillCache.TryGetValue(id, out var skill))
                {
                    heroSO.ActiveSkills.Add(skill);
                }
            }
        }
        else if (dto is WaveData waveDto &&
            so is WaveDataSO waveSO)
        {
            MonsterDataSO monster = monsterCache[waveDto.MonsterID];

            if (monster != null)
                waveSO.Monster = monster;
        }
        else if (dto is RecipeData recipeDto &&
            so is RecipeDataSO recipeSO)
        {
            recipeSO.ResultHero = heroCache[recipeDto.HeroID];

            if (materialCache.TryGetValue(recipeDto.RecipeID, out var list))
            {
                recipeSO.Materials = list;
            }
        }


    }

    public static Dictionary<int, T> BuildCache<T>() where T : ScriptableObject, IDataSO
    {
        Dictionary<int, T> cache = new();

        string[] guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            T asset = AssetDatabase.LoadAssetAtPath<T>(path);

            if (asset == null)
                continue;

            cache[asset.ID] = asset;
        }

        return cache;
    }

    private static void BuildRecipeMaterialCache()
    {
        materialCache = new();

        string json =
            File.ReadAllText("Assets/Resources/RecipeMaterialData.json");

        var list =
            JsonConvert.DeserializeObject<List<RecipeMaterialData>>(json);

        foreach (var dto in list)
        {
            if (!materialCache.TryGetValue(dto.RecipeID, out var materials))
            {
                materials = new List<RecipeMaterial>();
                materialCache.Add(dto.RecipeID, materials);
            }

            materials.Add(new RecipeMaterial
            {
                HeroData = heroCache[dto.HeroID],
                Count = dto.Count
            });
        }
    }
}
