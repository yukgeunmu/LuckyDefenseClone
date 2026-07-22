using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

public static class SOGenerator
{
    public static void Generate<TSO, TD>(string json, string savePath, string addressableGroup) where TSO : ScriptableObject
    {
        var list = JsonConvert.DeserializeObject<List<TD>>(json);

        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        foreach (var dto in list)
        {
            var asset = ScriptableObject.CreateInstance<TSO>();

            CopyFields(dto, asset);

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
        var doFields = typeof(TD).GetFields();
        var soFields = typeof(TSO).GetFields();

        foreach (var doField in doFields)
        {
            foreach (var soField in soFields)
            {
                if (doField.Name == soField.Name && doField.FieldType == soField.FieldType)
                {
                    var value = doField.GetValue(source);
                    soField.SetValue(target, value);
                }
            }
        }
    }

    static string GetFileName<TD>(TD dto)
    {
        var field = typeof(TD).GetField("rcode");

        if (field != null)
        {
            var value = field.GetValue(dto);
            return $"{value}";
        }

        return typeof(TD).Name;
    }
}
