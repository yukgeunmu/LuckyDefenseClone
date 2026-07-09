using LuckyDefense.Heroes;
using UnityEngine;


namespace LuckyDefense.Core.Events
{
    public struct HeroSoldEvent : IEvent
    {
        public Hero Hero { get; }

        public HeroSoldEvent(Hero hero)
        {
            Hero = hero;
        }
    }
}
