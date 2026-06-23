using LuckyDefense.Heroes.Data;
using UnityEngine;

namespace LuckyDefense.Heroes
{
    public class Hero
    {
        public HeroData Data { get; }

        public int Level { get; private set; } = 1;

        public Hero(HeroData data)
        {
            Data = data;
        }

        public int HeroID => Data.HeroID;

        public string HeroName => Data.HeroName;

        public HeroGrade Grade => Data.Grade;
    }
}

