using LuckyDefense.Heroes;
using LuckyDefense.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI
{
    public class SelectionUI : SceneUI
    {
        [Header("Hero Info")]
        [SerializeField] private GameObject heroInfoPanel;
        [SerializeField] private TextMeshProUGUI heroName;
        [SerializeField] private TextMeshProUGUI attack;
        [SerializeField] private TextMeshProUGUI attackSpeed;
        [SerializeField] private TextMeshProUGUI grade;
        [SerializeField] private Image icon;

        [Header("Buttons")]
        [SerializeField] private Button mergeButton;
        [SerializeField] private Button sellButton;

        public Button MergeButton => mergeButton;
        public Button SellButton => sellButton;

        public override void Initialize()
        {
            Hide();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            heroInfoPanel.SetActive(false);

            mergeButton.gameObject.SetActive(false);
            sellButton.gameObject.SetActive(false);
        }

        public void Refresh(Hero hero)
        {
            heroInfoPanel.SetActive(true);

            heroName.text = hero.Data.HeroName;
            attack.text = $"ATK {hero.Stats.Attack}";
            attackSpeed.text = $"ASPD {hero.Stats.AttackSpeed}";
            grade.text = hero.Data.Grade.ToString();

            // icon.sprite = hero.Data.Icon;
        }

        public void SetMergeVisible(bool value)
        {
            mergeButton.gameObject.SetActive(value);
        }

        public void SetSellVisible(bool value)
        {
            sellButton.gameObject.SetActive(value);
        }
    }
}