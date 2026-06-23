using LuckyDefense.Core;
using LuckyDefense.Heroes;

namespace LuckyDefense.Core.Events
{
    public struct HeroMergedEvent : IEvent
    {
        public Hero ResultHero;

        public HeroMergedEvent(Hero hero)
        {
            ResultHero = hero;
        }
    }
}