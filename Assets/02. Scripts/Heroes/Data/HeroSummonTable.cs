
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(         
        menuName = "Game/Hero/HeroSummonTable",
        fileName = "HeroSummonTable")]
    public class HeroSummonTable : ScriptableObject
    {
        public List<SummonRate> Rates;
    }
}