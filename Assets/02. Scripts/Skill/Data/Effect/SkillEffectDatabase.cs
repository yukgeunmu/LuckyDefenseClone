using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Skill.View
{
    [CreateAssetMenu(
        menuName = "Game/SkillEffectDatabase", fileName = "SkillEffectDatabase")]
    public class SkillEffectDatabase : ScriptableObject
    {
        public List<SkillEffectData> Effects = new();
    }
}