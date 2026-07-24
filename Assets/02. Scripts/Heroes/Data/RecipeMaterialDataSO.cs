using LuckyDefense.Core;
using System.Collections.Generic;
using UnityEngine;



namespace LuckyDefense.Heroes.Data
{
    [CreateAssetMenu(
        menuName = "Game/Hero/RecipeMaterial Data")]
    public class RecipeMaterialDataSO : ScriptableObject, IDataSO
    {
        public int RecipeID;
        public int ID => RecipeID;

        public List<RecipeMaterial> Materials = new();

    }

}

