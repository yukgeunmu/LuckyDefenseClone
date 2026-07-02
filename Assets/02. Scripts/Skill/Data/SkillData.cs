using UnityEngine;

namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/SkillData",fileName = "SkillData")]
    public class SkillData : ScriptableObject
    {
        public int SkillID;

        public string SkillName;

        public SkillCategory Category;

        public SkillType SkillType;

        public float Value;

        public float Radius;

        public float Duration;

        public int Cooldown;
    }
}