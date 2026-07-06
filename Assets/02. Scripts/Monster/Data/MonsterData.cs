
namespace LuckyDefense.Monsters.Data
{
    using UnityEngine;

    [CreateAssetMenu( fileName = "MonsterData", menuName = "Game/Monster/Monster Data")]
    public class MonsterData : ScriptableObject
    {
        [Header("Info")]
        public int MonsterID;

        public string MonsterName;

        public MonsterType Type;

        public MonsterRace Race;

        [Header("Stat")]
        public int MaxHp;

        public int Attack;

        public float MoveSpeed;

        [Header("Reward")]
        public int RewardGold;

        [Header("View")]
        public Sprite Icon;
    }
}