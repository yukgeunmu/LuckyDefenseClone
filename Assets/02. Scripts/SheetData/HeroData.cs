using LuckyDefense.Heroes.Data;
using System;
using System.Collections.Generic;


namespace LuckyDefense.SheetData
{
    [Serializable]
    public class HeroData
    {
        public int HeroID;
        public string HeroName;
        public HeroGrade Grade;
        public HeroClass ClassType;
        public HeroRace RaceType;
        public TargetType PrimaryTarget;
        public TargetType FallbackTarget;

        public int AttackPower;
        public float AttackSpeed;
        public float Range;
        public float ProjectileSpeed;

        public int SellPrice;

        public string Description;

        public List<int> PassiveSkillIDs = new();
        public List<int> ActiveSkillIDs = new();

        public HeroData() 
        { 
        }
    }

}


