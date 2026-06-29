using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero Data",
        fileName = "HeroData")]
    public class HeroData : ScriptableObject
    {
        [Header("기본 정보")]
        public int HeroID;
        public string HeroName;

        [Header("분류")]
        public HeroGrade Grade;
        public HeroClass ClassType;
        public HeroRace RaceType;

        [Header("전투")]
        public int AttackPower;
        public float AttackSpeed;
        public float Range;

        [Header("설명")]
        [TextArea]
        public string Description;
    }
}