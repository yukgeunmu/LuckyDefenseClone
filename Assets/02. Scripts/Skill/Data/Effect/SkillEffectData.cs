using UnityEngine;

namespace LuckyDefense.Skill.View
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillEffectData", fileName ="SkillEffectData")]
    public class SkillEffectData : ScriptableObject
    {
        public SkillEffectType Type;

        public SkillEffectView Prefab;
    }
}