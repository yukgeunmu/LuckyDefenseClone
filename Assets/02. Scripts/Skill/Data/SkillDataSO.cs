using LuckyDefense.Core;
using LuckyDefense.Skill.Passive;
using LuckyDefense.StatusEffects;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Skill.Data
{
    [CreateAssetMenu(
        menuName = "Game/Skill/SkillData",fileName = "SkillData")]
    public class SkillDataSO : ScriptableObject, IDataSO
    {
        public int SkillID;

        public int ID => SkillID;

        public string SkillName;

        public SkillCategory Category;

        public SkillClass SkillClass;

        public StatusEffectType StatusEffectType;

        public SkillLogicType LogicType;

        public float Value;

        public float StatusEffectValue;

        public float Radius;

        public float Duration;

        public int Cooldown;

        public int Count;

        public float Speed;

        public AssetReferenceGameObject EffectPrefab;

        public AssetReferenceGameObject ProjectilePrefab;

        public AssetReferenceGameObject OrbitPrefab;

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(SkillName))
            {
                SkillName = this.name;
            }
        }
    }
}