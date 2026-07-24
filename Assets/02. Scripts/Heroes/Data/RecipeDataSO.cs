using LuckyDefense.Core;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero/Recipe Data")]
    public class RecipeDataSO : ScriptableObject, IDataSO
    {
        public int RecipeID;

        public int ID => RecipeID;

        public HeroDataSO ResultHero;

        public List<RecipeMaterial> Materials;
    }
}