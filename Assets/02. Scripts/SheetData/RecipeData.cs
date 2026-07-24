using LuckyDefense.Heroes.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.SheetData
{
    public class RecipeData
    {
        public int RecipeID;

        public int HeroID;

        public List<RecipeMaterial> Materials;

        public RecipeData() { }

    }
}

