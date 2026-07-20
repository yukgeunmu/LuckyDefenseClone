using LuckyDefense.Heroes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefense.UI.Scene
{
    public class HeroInfoPanel : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI heroName;
        [SerializeField] private TextMeshProUGUI attack;
        [SerializeField] private TextMeshProUGUI attackSpeed;
        [SerializeField] private TextMeshProUGUI grade;
        [SerializeField] private List<TextMeshProUGUI> PassiveSkill;
        [SerializeField] private List<TextMeshProUGUI> ActiveSkill;


        public void Refresh(Hero hero)
        {
            if (hero == null)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            heroName.text = hero.Data.HeroName;
            attack.text = $"ATK {hero.Stats.Attack}";
            attackSpeed.text = $"ASPD {hero.Stats.AttackSpeed}";
            grade.text = hero.Grade.ToString();

            //if (hero.SkillComponent.ActiveSkills.Count > 0)
            //    ActiveSkill.text = hero.SkillComponent.ActiveSkills[0].Data.SkillName;
            //else
            //    ActiveSkill.text = "-";
        }
    }
}