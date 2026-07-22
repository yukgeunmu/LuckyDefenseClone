using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;


public class GoogleSheetAPIImporter : EditorWindow
{
    // 시트 아이디 https://docs.google.com/spreadsheets/d/"시트 아이디"/edit?usp=sharing
    private string sheetId = "";
    // 구글 API 키
    private string apiKey = "";
    // 저장 할 위치
    private string saveFolder = "Assets/Resources/";
    private string addressableGroup = "";

    [MenuItem("Tools/Google Sheet API Importer")]
    public static void ShowWindow()
    {
        GetWindow<GoogleSheetAPIImporter>("Sheet API Importer");
    }

    void OnGUI()
    {

        GUILayout.Label("Google Sheets API Import", EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();

        sheetId = EditorGUILayout.TextField("Sheet ID", sheetId);
        apiKey = EditorGUILayout.TextField("API Key", apiKey);
        saveFolder = EditorGUILayout.TextField("Save Folder", saveFolder);
        addressableGroup = EditorGUILayout.TextField("Addressable Group", addressableGroup);

        // 처음 입력 시 저장
        if (EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetString("SheetID", sheetId);
            EditorPrefs.SetString("ApiKey", apiKey);
            EditorPrefs.SetString("SaveFolder", saveFolder);
            EditorPrefs.SetString("AddressableGroup", addressableGroup);
        }

        if (GUILayout.Button("Import All Sheets"))
        {
            ImportAll();
        }
    }

    void OnEnable()
    {
        sheetId = EditorPrefs.GetString("SheetID", "");
        apiKey = EditorPrefs.GetString("ApiKey", "");
        saveFolder = EditorPrefs.GetString("SaveFolder", saveFolder);
        addressableGroup = EditorPrefs.GetString("AddressableGroup", addressableGroup);
    }

    void ImportAll()
    {
        try
        {
            // 1. 시트 목록 가져오기
            string metaUrl = $"https://sheets.googleapis.com/v4/spreadsheets/{sheetId}?key={apiKey}";
            string metaJson = Download(metaUrl);

            var meta = JsonUtility.FromJson<SheetMetaResponse>(metaJson);

            foreach (var sheet in meta.sheets)
            {
                string title = sheet.properties.title;

                Debug.Log($"Fetching: {title}");

                // 2. 데이터 가져오기
                string range = $"{title}!A:L";
                string dataUrl = $"https://sheets.googleapis.com/v4/spreadsheets/{sheetId}/values/{range}?key={apiKey}";

                string dataJson = Download(dataUrl);

                var data = JsonConvert.DeserializeObject<SheetValueResponse>(dataJson);

                if (data.values == null || data.values.Count < 3)
                {
                    Debug.LogWarning($"{title} 데이터 없음");
                    continue;
                }

                var headers = data.values[0];
                var types = data.values[1];

                List<Dictionary<string, object>> result = new();

                // 3. 데이터 파싱
                for (int i = 2; i < data.values.Count; i++)
                {
                    var row = data.values[i];
                    Dictionary<string, object> rowObj = new();

                    for (int j = 0; j < headers.Count; j++)
                    {
                        string header = headers[j].Trim();
                        string type = j < types.Count ? types[j].Trim() : "";
                        string value = j < row.Count ? row[j].Trim() : "";

                        rowObj[header] = ParseValue(type, value);
                    }

                    result.Add(rowObj);
                }

                // 4. JSON 저장
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                string path = Path.Combine(saveFolder, $"{title}.json");
                File.WriteAllText(path, json);

                AssetDatabase.Refresh();

                AddressableRegister.AddToAddressable(path, addressableGroup);
                Debug.Log($"{title} 저장 완료");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    string Download(string url)
    {
        using (WebClient client = new WebClient())
        {
            client.Encoding = System.Text.Encoding.UTF8;
            return client.DownloadString(url);
        }
    }

    object ParseValue(string type, string value)
    {
        if (string.IsNullOrEmpty(value))
            return type == "string" ? "" : 0;

        switch (type)
        {
            case "int":
                return int.TryParse(value, out var i) ? i : 0;
            case "float":
                return float.TryParse(value, out var f) ? f : 0f;
            case "bool":
                return bool.TryParse(value, out var b);
            case "int[]":
                return value
                    .Split(',')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(int.Parse)
                    .ToList();
            default:
                return value;
        }
    }

    // 어드레서블 등록
    private void AddToAddressable(string assetPath)
    {
        var settings = AddressableAssetSettingsDefaultObject.Settings;

        if (settings == null)
        {
            Debug.LogError("Addressable Settings not found");
            return;
        }

        // GUID 가져오기
        string guid = AssetDatabase.AssetPathToGUID(assetPath);

        var entry = settings.FindAssetEntry(guid);

        if (entry == null)
        {
            // 기본 그룹
            var group = settings.FindGroup(addressableGroup);


            if (group == null)
            {
                group = settings.CreateGroup(
                    addressableGroup,
                    false,
                    false,
                    false,
                    null,
                    typeof(UnityEditor.AddressableAssets.Settings.GroupSchemas.BundledAssetGroupSchema)
                );
            }

            entry = settings.CreateOrMoveEntry(guid, group);
            entry.address = Path.GetFileNameWithoutExtension(assetPath);
        }

        AssetDatabase.SaveAssets();

    }


}


[System.Serializable]
public class SheetMetaResponse
{
    public Sheet[] sheets;
}

[System.Serializable]
public class Sheet
{
    public SheetProperties properties;
}

[System.Serializable]
public class SheetProperties
{
    public string title;
}

[System.Serializable]
public class SheetValueResponse
{
    public string range { get; set; }
    public string majorDimension { get; set; }
    public List<List<string>> values { get; set; }
}
