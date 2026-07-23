using LuckyDefense.Heroes.Data;
using LuckyDefense.SheetData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectGenerator : EditorWindow
{
    private string jsonPath = "Assets/Resources";

    private string savePath = "Assets/Data/Item";

    private string addressableGroup = "";

    [MenuItem("Tools/ScriptableObject Generator")]
    public static void ShowWindow()
    {
        GetWindow<ScriptableObjectGenerator>("ScriptableObject Generator");
    }

    void OnGUI()
    {
        GUILayout.Label("ScriptableObject Generator", EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();

        jsonPath = EditorGUILayout.TextField("JSON Path", jsonPath);
        savePath = EditorGUILayout.TextField("Save Path", savePath);
        addressableGroup = EditorGUILayout.TextField("Addressable Group", addressableGroup);

        if (GUILayout.Button("Generate ScriptableObjects"))
        {
            string json = File.ReadAllText(jsonPath);

            string fileName = Path.GetFileNameWithoutExtension(jsonPath);

            string soName = $"{fileName}SO";

            var soType = FindType(soName); // HeroDataSO
            var dtoType = FindType(fileName); // HeroData

            if (soType != null && dtoType != null)
            {
                // 1. Generate 메서드 정보를 가져옵니다. 
                // (메서드 이름과 매개변수 개수 등으로 검색)
                var method = typeof(SOGenerator).GetMethod("Generate");

                // 2. 메서드에 제네릭 타입(soType, dtoType)을 주입합니다.
                var genericMethod = method.MakeGenericMethod(soType, dtoType);

                // 3. 메서드 실행 (매개변수 순서대로 배열에 담아 전달)
                genericMethod.Invoke(null, new object[] { json, savePath, addressableGroup });
            }
            else
            {
                Debug.LogError("타입을 찾을 수 없습니다. 클래스 이름이나 네임스페이스를 확인하세요.");
            }
        }

    }

    private static Type FindType(string className)
    {
        return AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == className);
    }


}
