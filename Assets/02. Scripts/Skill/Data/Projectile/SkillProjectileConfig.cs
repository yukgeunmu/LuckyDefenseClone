using LuckyDefense.Heroes.View;
using UnityEngine;


namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/ProjectileData", fileName = "ProjectileData")]
    public class SkillProjectileConfig : ScriptableObject
    {
        public SkillProjectileType Type;

        public ProjectileView Prefab;
    }
}



