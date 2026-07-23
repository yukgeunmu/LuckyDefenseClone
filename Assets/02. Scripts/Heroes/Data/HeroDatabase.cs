using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero/Hero Database",
        fileName = "HeroDatabase")]
    public class HeroDatabase : ScriptableObject
    {
        public List<HeroDataSO> Heroes;
    }
}