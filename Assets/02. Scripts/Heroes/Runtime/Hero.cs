using LuckyDefense.Board;
using LuckyDefense.Heroes.Buff;
using LuckyDefense.Heroes.Data;
using UnityEngine;

namespace LuckyDefense.Heroes
{
    public class Hero
    {
        public HeroData Data { get; }

        public HeroStats Stats { get; }
        public HeroBuffController BuffController { get; }

        public int Level { get; private set; } = 1;

        public GridCell CurrentCell
        {
            get;
            internal set;
        }

        public Hero(HeroData data)
        {
            Data = data;

            Stats = new HeroStats(data);
        }

        public int HeroID => Data.HeroID;

        public string HeroName => Data.HeroName;

        public HeroGrade Grade => Data.Grade;
    }
}

