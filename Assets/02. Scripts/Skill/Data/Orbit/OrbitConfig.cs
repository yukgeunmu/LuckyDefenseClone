using UnityEngine;
using UnityEngine.AddressableAssets;


namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/OrbitData", fileName = "OrbitData")]
    public class OrbitConfig : ScriptableObject
    {
        public OrbitType type;

        public AssetReferenceGameObject ViewPrefab;
    }
}

