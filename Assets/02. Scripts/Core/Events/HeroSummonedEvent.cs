using LuckyDefense.Core;
using LuckyDefense.Heroes;

namespace LuckyDefense.Core.Events
{
    public struct HeroSummonedEvent : IEvent
    {
        public Hero Hero;

        public HeroSummonedEvent(Hero hero)
        {
            Hero = hero;
        }
    }
}