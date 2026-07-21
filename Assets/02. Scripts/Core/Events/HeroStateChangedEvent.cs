using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Animation;


namespace LuckyDefense.Core.Events
{
    public struct HeroStateChangedEvent : IEvent
    {
        public Hero Hero;
        public HeroStateType State;


        public HeroStateChangedEvent(Hero hero, HeroStateType state)
        {
            this.Hero = hero;
            this.State = state;
        }
    }
}

