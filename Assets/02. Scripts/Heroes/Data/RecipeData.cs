using LuckyDefense.Heroes.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero/Recipe Data")]
    public class RecipeData : ScriptableObject
    {
        public int RecipeID;

        public HeroDataSO ResultHero;

        public List<RecipeMaterial> Materials;
    }
}