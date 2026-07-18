using LuckyDefense.Skill.Passive;
using LuckyDefense.StatusEffects;
using UnityEngine;

namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillData",fileName = "SkillData")]
    public class SkillData : ScriptableObject
    {
        public int SkillID;

        public string SkillName;

        public SkillCategory Category;

        public SkillClass SkillClass;

        public StatusEffectType StatusEffectType;

        public SkillLogicType LogicType;

        public SkillEffectType SkillEffect;

        public ProjectileType ProjectileType;

        public float Value;

        public float StatusEffectValue;

        public float Radius;

        public float Duration;

        public int Cooldown;

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(SkillName))
            {
                SkillName = this.name;
            }
        }
    }
}