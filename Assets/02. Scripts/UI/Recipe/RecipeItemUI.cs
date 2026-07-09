using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI.Recipe
{
    public class RecipeItemUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text resultName;
        [SerializeField] private TMP_Text materials;
        [SerializeField] private Button mergeButton;

        private RecipeData recipe;

        public void Initialize(RecipeData recipe)
        {
            this.recipe = recipe;

            resultName.text = recipe.ResultHero.HeroName;

            materials.text = "";

            foreach (var material in recipe.Materials)
            {
                materials.text +=
                    $"{material.HeroData.HeroName} x{material.Count}\n";
            }

            mergeButton.onClick.RemoveAllListeners();
            mergeButton.onClick.AddListener(OnClickMerge);
        }

        private void OnClickMerge()
        {
            GameManager.Instance.Merge.RecipeService.Merge(recipe);
        }
    }
}