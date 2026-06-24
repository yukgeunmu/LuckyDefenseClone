using LuckyDefense.Heroes;
using LuckyDefense.Heroes.View;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Core.Manager
{
    public class HeroViewManager
    {
        private readonly Dictionary<Hero, HeroView> heroViews = new();

        public void Register(Hero hero, HeroView view)
        {
            heroViews.Add(hero, view);
        }

        public HeroView GetView(Hero hero)
        {
            heroViews.TryGetValue( hero, out HeroView view);

            return view;
        }

        public void Remove(Hero hero)
        {
            if (!heroViews.TryGetValue(
                hero,
                out HeroView view))
                return;

            Object.Destroy(
                view.gameObject);

            heroViews.Remove(hero);
        }


    }
}