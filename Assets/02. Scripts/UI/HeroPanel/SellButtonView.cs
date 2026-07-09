using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI.HeroPanel
{
    public class SellButtonView : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        public Button Button => button;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetInteractable(bool value)
        {
            button.interactable = value;
        }
    }
}