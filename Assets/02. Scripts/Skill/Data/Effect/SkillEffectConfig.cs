using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Skill.View
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillEffectData", fileName ="SkillEffectData")]
    public class SkillEffectConfig : ScriptableObject
    {
        public SkillEffectType Type;

        public AssetReferenceGameObject ViewPrefab;

    }
}