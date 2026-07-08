using UnityEngine;
using UnityEngine.UI;


namespace LuckyDefense.UI.HeroPanel
{
    public class MergeButtonView : MonoBehaviour
    {
        [SerializeField]
        private Button MergeButton;

        public Button Button => MergeButton;

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
            MergeButton.interactable = value;
        }
    }
}

