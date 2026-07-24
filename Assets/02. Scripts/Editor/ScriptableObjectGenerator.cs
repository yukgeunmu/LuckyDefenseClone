using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectGenerator : EditorWindow
{
    private string jsonFolder = "";

    [MenuItem("Tools/ScriptableObject Generator")]
    public static void ShowWindow()
    {
        GetWindow<ScriptableObjectGenerator>("ScriptableObject Generator");
    }

    void OnGUI()
    {
        GUILayout.Label("ScriptableObject Generator Total Save");

        jsonFolder = EditorGUILayout.TextField("JSON Path", jsonFolder);

        if (GUILayout.Button("Generate ScriptableObjects"))
        {
            ImportAll();
        }
    }

    private void ImportAll()
    {
        GenerateSoonOnly("SkillData");
        GenerateSoonOnly("HeroData");
        GenerateSoonOnly("MonsterData");
        GenerateSoonOnly("RecipeData");
        GenerateSoonOnly("WaveData");


        SOGenerator.Initialize();

        ResolveAllReference("SkillData");
        ResolveAllReference("HeroData");
        ResolveAllReference("RecipeData");
        ResolveAllReference("WaveData");


        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Data Import Complete");
    }


    private void GenerateSoonOnly(string fileName)
    {
        string jsonPath = $"Assets/{jsonFolder}/{fileName}.json";
        string savePath = $"Assets/04.Data/{fileName.Replace("Data", "")}";

        string json = File.ReadAllText(jsonPath);

        var soType = FindType($"{fileName}SO");
        var dtoType = FindType(fileName);

        var preprocess = typeof(SOGenerator).GetMethod(nameof(SOGenerator.Preprocessing));

        preprocess.MakeGenericMethod(soType, dtoType).Invoke(null, new object[]
        {
                json,
                savePath
        });
    }

    private void ResolveAllReference(string fileName)
    {
        string jsonPath = $"Assets/{jsonFolder}/{fileName}.json";
        string savePath = $"Assets/04.Data/{fileName.Replace("Data", "")}";

        string json = File.ReadAllText(jsonPath);

        var soType = FindType($"{fileName}SO");
        var dtoType = FindType(fileName);

        var preprocess = typeof(SOGenerator).GetMethod(nameof(SOGenerator.ResolveAllReference));

        preprocess.MakeGenericMethod(soType, dtoType).Invoke(null, new object[]
        {
                json,
                savePath
        });
    }

    private static Type FindType(string className)
    {
        return AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == className);
    }

}
