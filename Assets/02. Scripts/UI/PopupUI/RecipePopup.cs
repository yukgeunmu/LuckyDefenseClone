using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using LuckyDefense.UI.Base;
using LuckyDefense.UI.Recipe;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI.Popup
{
    public class RecipePopup : PopupUI
    {
        [SerializeField]
        private Transform content;

        [SerializeField]
        private RecipeItemUI recipeItemPrefab;

        [SerializeField]
        private Button closeButton;

        private readonly List<RecipeItemUI> items = new();

        public override void Show()
        {
            base.Show();

            Refresh();
        }

        private void OnEnable()
        {
            closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(Close);
        }

        private void Refresh()
        {
            Clear();

            List<RecipeData> recipes =
                GameManager.Instance.Merge.RecipeService.GetAvailableRecipes();

            foreach (RecipeData recipe in recipes)
            {
                RecipeItemUI item =
                    Instantiate(recipeItemPrefab, content);

                item.Initialize(recipe);

                items.Add(item);
            }
        }

        private void Clear()
        {
            foreach (RecipeItemUI item in items)
            {
                Destroy(item.gameObject);
            }

            items.Clear();
        }
    }
}