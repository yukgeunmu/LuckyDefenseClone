using LuckyDefense.Monsters.Data;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace LuckyDefense.SheetData
{
    [Serializable]
    public class MonsterData
    {
        public int MonsterID;

        public string MonsterName;

        public MonsterType Type;

        public MonsterRace Race;

        public int MaxHp;

        public int Attack;

        public float MoveSpeed;

        public int RewardGold;

        public MonsterData()
        {
        }


}

}

