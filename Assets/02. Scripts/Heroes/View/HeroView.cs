using LuckyDefense.Heroes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LuckyDefense.Heroes.View
{
    public class HeroView : MonoBehaviour
    {
        public Hero Hero { get; private set; }
        public SpriteRenderer spriteRenderer; 

        private Vector3 originalPosition;
        private Transform originalParent;

        public void Init(Hero hero)
        {
            Hero = hero;

            gameObject.name =
                $"{hero.HeroName}";

            switch (hero.Grade)
            {
                case Data.HeroGrade.Common:
                    spriteRenderer.color = Color.white;
                    break;
                case Data.HeroGrade.Rare:
                    spriteRenderer.color = Color.blue;
                    break;
                case Data.HeroGrade.Epic:
                    spriteRenderer.color = Color.violet;
                    break;
                case Data.HeroGrade.Legendary:
                    spriteRenderer.color = Color.yellowNice;
                    break;
                case Data.HeroGrade.Mythic:
                    spriteRenderer.color = Color.blueViolet;
                    break;
            }
        }
    }
}