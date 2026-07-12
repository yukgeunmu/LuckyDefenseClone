using LuckyDefense.Heroes.View;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/ProjectileData", fileName = "ProjectileData")]
    public class ProjectileConfig : ScriptableObject
    {
        public ProjectileType Type;

        public AssetReferenceGameObject ViewPrefab;
    }
}



