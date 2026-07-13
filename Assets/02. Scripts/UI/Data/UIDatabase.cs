using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;



namespace LuckyDefense.UI.Data
{
    [CreateAssetMenu(fileName = "UIDatabase", menuName = "Game/UI/UIDatabase")]
    public class UIDatabase : ScriptableObject
    {
        public List<UIEntry> entries;
    }
}

