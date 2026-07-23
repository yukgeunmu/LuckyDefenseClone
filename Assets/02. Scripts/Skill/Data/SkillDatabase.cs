using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
    menuName = "Game/Skill/SkillDatabase", fileName = "SkillDatabase")]
    public class SkillDatabase : ScriptableObject
    {
        public List<SkillDataSO> Skills;
    }
}



