namespace LuckyDefense.Heroes.States
{
    public abstract class HeroBaseState : IState
    {
        protected readonly HeroStateMachine stateMachine;

        protected Hero Hero => stateMachine.Hero;

        protected HeroBaseState(HeroStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }
    }
}