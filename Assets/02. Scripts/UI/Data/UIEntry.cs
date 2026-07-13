using System;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.UI.Data
{
    [Serializable]
    public class UIEntry
    {
        public UIKey Type;
        public string TypeName => Type.ToString();
        public AssetReferenceGameObject Prefab;
    }
}

