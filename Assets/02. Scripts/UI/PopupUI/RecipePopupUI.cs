using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.Data;
using LuckyDefense.UI.Base;
using LuckyDefense.UI.Recipe;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace LuckyDefense.UI.Popup
{
    public class RecipePopupUI : PopupUI
    {
        [SerializeField]
        private Transform content;

        [SerializeField]
        private AssetReferenceGameObject recipeItemPrefab;

        [SerializeField]
        private Button closeButton;

        private readonly List<RecipeSlotUI> items = new();

        public override void Show()
        {
            base.Show();

            Refresh().Forget();
        }

        private void OnEnable()
        {
            closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(Close);
        }

        private async UniTask Refresh()
        {
            Clear();

            List<RecipeData> recipes =
                GameManager.Instance.Merge.RecipeService.GetAvailableRecipes();

            foreach (RecipeData recipe in recipes)
            {
                RecipeSlotUI item = await GameManager.Instance.Pool.Get<RecipeSlotUI>(recipeItemPrefab, content);

                item.Initialize(recipe);

                items.Add(item);
            }
        }

        private void Clear()
        {
            foreach (RecipeSlotUI item in items)
            {
                GameManager.Instance.Pool.Release(item.gameObject);
            }

            items.Clear();
        }
    }
}