using LuckyDefense.Core;
using LuckyDefense.Heroes.Data;
using LuckyDefense.SheetData;
using LuckyDefense.Skill.Data;
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

    public static void Generate<TSO, TD>(string json, string savePath, string addressableGroup) where TSO : ScriptableObject
    {
        skillCache = BuildCache<SkillDataSO>();

        var list = JsonConvert.DeserializeObject<List<TD>>(json);

        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);


        foreach (var dto in list)
        {
            var asset = ScriptableObject.CreateInstance<TSO>();

            CopyFields(dto, asset);

            ResolveReference(dto, asset);

            string fileName = GetFileName(dto);
            string path = $"{savePath}/{fileName}.asset";

            var existing = AssetDatabase.LoadAssetAtPath<TSO>(path);

            if (existing != null)
            {
                CopyFields(dto, existing);
                EditorUtility.SetDirty(existing);
            }
            else
            {
                AssetDatabase.CreateAsset(asset, path);
            }

            AddressableRegister.AddToAddressable(path, addressableGroup);

        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
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

    //static void CopyFields<TD, TSO>(TD source, TSO target)
    //{
    //    var doFields = typeof(TD).GetFields();
    //    var soFields = typeof(TSO).GetFields();

    //    foreach (var doField in doFields)
    //    {
    //        foreach (var soField in soFields)
    //        {
    //            if (doField.Name == soField.Name && doField.FieldType == soField.FieldType)
    //            {
    //                var value = doField.GetValue(source);
    //                soField.SetValue(target, value);
    //            }
    //        }
    //    }
    //}

    static string GetFileName<TD>(TD dto)
    {
        Type type = typeof(TD);

        var idField =
            type.GetField("HeroID") ??
            type.GetField("MonsterID") ??
            type.GetField("SkillID") ??
            type.GetField("RecipeID") ??
            type.GetField("ID");

        if (idField == null)
            return Guid.NewGuid().ToString();

        string className = type.Name.Replace("Data", "").ToUpper();

        return $"{className}{idField.GetValue(dto)}";
    }

    //static string GetFileName<TD>(TD dto)
    //{
    //    var field = typeof(TD).GetField("rcode");

    //    if (field != null)
    //    {
    //        var value = field.GetValue(dto);
    //        return $"{value}";
    //    }

    //    return typeof(TD).Name;
    //}

    static void ResolveReference<TD, TSO>(TD dto, TSO so)
    {
        if (dto is HeroData heroDto &&
            so is HeroDataSO heroSO)
        {
            heroSO.PassiveSkills.Clear();

            foreach (int id in heroDto.PassiveSkillIDs)
            {
                if (id == 0)
                    continue;

                SkillDataSO skill = skillCache[id];

                if (skill != null)
                    heroSO.PassiveSkills.Add(skill);
            }

            heroSO.ActiveSkills.Clear();

            foreach (int id in heroDto.ActiveSkillIDs)
            {
                if (id == 0)
                     continue;

                SkillDataSO skill = skillCache[id];

                if (skill != null)
                    heroSO.ActiveSkills.Add(skill);
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
}
