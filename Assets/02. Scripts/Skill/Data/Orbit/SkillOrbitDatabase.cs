using System.Collections.Generic;
using UnityEngine;


namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillOrbitDatabase", fileName = "SkillOrbitDatabase")]
    public class SkillOrbitDatabase : ScriptableObject
    {
        public List<OrbitConfig> SkillOrbitConfigs = new();
    }

}


