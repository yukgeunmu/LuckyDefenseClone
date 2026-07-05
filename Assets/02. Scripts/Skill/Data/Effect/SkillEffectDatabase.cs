using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Skill.View
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillEffectDatabase", fileName = "SkillEffectDatabase")]
    public class SkillEffectDatabase : ScriptableObject
    {
        public List<SkillEffectData> Effects = new();
    }
}