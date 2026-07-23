using LuckyDefense.Core;
using LuckyDefense.Skill.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero/Hero Data",
        fileName = "HeroData")]
    public class HeroDataSO : ScriptableObject, IDataSO
    {
        [Header("Info")]
        public int HeroID;
        public int ID => HeroID;
        public string HeroName;


        [Header("Type")]
        public HeroGrade Grade;
        public HeroClass ClassType;
        public HeroRace RaceType;
        public TargetType PrimaryTarget;
        public TargetType FallbackTarget;


        [Header("Battle")]
        public int AttackPower;
        public float AttackSpeed;
        public float Range;
        public float ProjectileSpeed = 10f;

        [Header("Sell")]
        public int SellPrice;

        [Header("Passive Skills")]
        public List<SkillDataSO> PassiveSkills = new();

        [Header("Active Skills")]
        public List<SkillDataSO> ActiveSkills = new();

        [Header("Description")]
        [TextArea]
        public string Description;

        [Header("Prefab")]
        public AssetReferenceGameObject ViewPrefab;
        public AssetReferenceGameObject ProjectilePrefab;

    }
}