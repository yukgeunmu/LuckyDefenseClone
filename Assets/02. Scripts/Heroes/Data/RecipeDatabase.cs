using LuckyDefense.Heroes.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Recipe Database")]
    public class RecipeDatabase : ScriptableObject
    {
        public List<RecipeData> Recipes;
    }
}