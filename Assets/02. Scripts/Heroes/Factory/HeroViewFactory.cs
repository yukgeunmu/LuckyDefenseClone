using LuckyDefense.Heroes;
using LuckyDefense.Heroes.View;
using UnityEngine;

namespace LuckyDefense.Heroes.Factory
{
    public class HeroViewFactory
    {
        private HeroView prefab;

        public HeroViewFactory(HeroView prefab)
        {
            this.prefab = prefab;
        }

        public HeroView Create( Hero hero, Transform parent)
        {
            HeroView view =
                Object.Instantiate(
                    prefab,
                    parent);

            view.Init(hero);

            return view;
        }
    }
}