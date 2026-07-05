using System.Collections.Generic;
using UnityEngine;


namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillProjectileDatabase", fileName = "SkillProjectileDatabase")]
    public class SkillProjectileDatabase : ScriptableObject
    {
        public List<SkillProjectileConfig> SkillProjectileConfigs = new();
    }

}
