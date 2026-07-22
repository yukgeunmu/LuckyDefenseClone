using UnityEngine;
using UnityEditor.AddressableAssets;
using UnityEditor;
using System.IO;
public static class AddressableRegister
{
    // 어드레서블 등록
    public static void AddToAddressable(string assetPath, string addressableGroup)
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
