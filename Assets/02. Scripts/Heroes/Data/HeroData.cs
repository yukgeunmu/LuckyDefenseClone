using LuckyDefense.Skill.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero Data",
        fileName = "HeroData")]
    public class HeroData : ScriptableObject
    {
        [Header("Info")]
        public int HeroID;
        public string HeroName;

        [Header("Type")]
        public HeroGrade Grade;
        public HeroClass ClassType;
        public HeroRace RaceType;
        public TargetType PrimaryTarget;
        public TargetType FallbackTarget;
        public ProjectileType ProjectileType;


        [Header("Battle")]
        public int AttackPower;
        public float AttackSpeed;
        public float Range;
        public float ProjectileSpeed = 10f;

        [Header("Passive Skills")]
        public List<SkillData> PassiveSkills = new();

        [Header("Active Skills")]
        public List<SkillData> ActiveSkills = new();

        [Header("Description")]
        [TextArea]
        public string Description;
    }
}