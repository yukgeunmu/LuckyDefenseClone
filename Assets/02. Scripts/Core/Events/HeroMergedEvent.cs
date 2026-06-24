using LuckyDefense.Core;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core.Events
{
    public struct HeroMergedEvent : IEvent
    {
        public IReadOnlyList<Hero> ConsumedHeroes { get; }

        public Hero ResultHero;

        public HeroMergedEvent(Hero hero, IReadOnlyList<Hero> consumedHeroes)
        {
            ResultHero = hero;
            ConsumedHeroes = consumedHeroes;
        }
    }
}