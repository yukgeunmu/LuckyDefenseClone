namespace LuckyDefense.Heroes.States
{
    public class HeroStateMachine : StateMachine
    {
        public Hero Hero { get; }

        public HeroIdleState Idle { get; private set; }
        public HeroAttackState Attack { get; private set; }
        public HeroMoveState Move { get; private set; }


        public HeroStateMachine(Hero hero)
        {
            Hero = hero;
            Idle = new HeroIdleState(this);
            Attack = new HeroAttackState(this);
            Move = new HeroMoveState(this);
        }
    }
}