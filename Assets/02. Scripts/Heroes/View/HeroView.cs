using LuckyDefense.Heroes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LuckyDefense.Heroes.View
{
    public class HeroView : MonoBehaviour
    {
        public Hero Hero { get; private set; }

        private Vector3 originalPosition;
        private Transform originalParent;

        public void Init(Hero hero)
        {
            Hero = hero;

            gameObject.name =
                $"{hero.HeroName}";
        }
    }
}