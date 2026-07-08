using LuckyDefense.Heroes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace LuckyDefense.UI.HeroPanel
{
    public class HeroInfoView : MonoBehaviour
    {
        [SerializeField] private GameObject root;

        [SerializeField] private Image icon;

        [SerializeField] private TextMeshProUGUI heroName;

        [SerializeField] private TextMeshProUGUI attack;

        [SerializeField] private TextMeshProUGUI attackSpeed;

        [SerializeField] private TextMeshProUGUI grade;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Refresh(Hero hero)
        {
            heroName.text = hero.Data.HeroName;
            attack.text = hero.Stats.Attack.ToString();
            attackSpeed.text = hero.Stats.AttackSpeed.ToString("0.00");
            grade.text = hero.Data.Grade.ToString();

            // icon.sprite = hero.Data.Icon;
        }
    }
}
