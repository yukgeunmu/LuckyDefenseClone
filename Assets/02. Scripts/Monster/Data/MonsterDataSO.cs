
namespace LuckyDefense.Monsters.Data
{
    using LuckyDefense.Core;
    using LuckyDefense.Monsters.View;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [CreateAssetMenu( fileName = "MonsterData", menuName = "Game/Monster/Monster Data")]
    public class MonsterDataSO : ScriptableObject, IDataSO
    {
        [Header("Info")]
        public int MonsterID;
        public int ID => MonsterID;

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
        public AssetReferenceGameObject ViewPrefab;
        public Sprite Icon;

    }
}