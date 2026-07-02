namespace LuckyDefense.Monsters.States
{
    public abstract class MonsterBaseState : IState
    {
        protected readonly MonsterStateMachine stateMachine;
        protected Monster Monster => stateMachine.Monster;

        protected MonsterBaseState(MonsterStateMachine stateMachine)
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