using LuckyDefense.Core.Manager;
using LuckyDefense.Core.Pool;
using LuckyDefense.Heroes.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI.Recipe
{
    public class RecipeSlotUI : MonoBehaviour, IPoolable
    {
        [SerializeField] private TMP_Text resultName;
        [SerializeField] private TMP_Text materials;
        [SerializeField] private Button mergeButton;

        private RecipeDataSO recipe;

        public void Initialize(RecipeDataSO recipe)
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

        public void OnDespawn()
        {
        }

        public void OnSpawn()
        {
        }

        private void OnClickMerge()
        {
            GameManager.Instance.Merge.RecipeService.Merge(recipe);
        }
    }
}