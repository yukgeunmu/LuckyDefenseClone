namespace LuckyDefense.Heroes.States
{
    public class HeroStateMachine : StateMachine
    {
        public Hero Hero { get; }

        public HeroStateMachine(Hero hero)
        {
            Hero = hero;
        }
    }
}