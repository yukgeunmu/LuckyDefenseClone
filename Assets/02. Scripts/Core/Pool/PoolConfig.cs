using LuckyDefense.Heroes.View;
using LuckyDefense.Monsters.View;
using LuckyDefense.UI;
using UnityEngine;


namespace LuckyDefense.Core.Pool
{
    [CreateAssetMenu(
        menuName = "Game/Pool/PoolConfig",
        fileName = "PoolConfig")]
    public class PoolConfig : ScriptableObject
    {
        [Header("Hero")]
        public HeroView BaseHeroView;

        [Header("Monster")]
        public MonsterView BaseMonsterView;

        [Header("Projectile")]
        public ProjectileView NoneView;
        public ProjectileView ArrowView;

        [Header("UI")]
        public DamageTextView DamageTextView;

    }

}

