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

        //public void OnBeginDrag(PointerEventData eventData)
        //{
        //    originalPosition =
        //        transform.position;

        //    originalParent =
        //        transform.parent;
        //}

        //public void OnDrag(PointerEventData eventData)
        //{
        //    transform.position =
        //        eventData.position;
        //}

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //}
    }
}