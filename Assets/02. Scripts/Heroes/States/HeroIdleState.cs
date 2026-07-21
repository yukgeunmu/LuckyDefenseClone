using LuckyDefense.Core.Events;
using LuckyDefense.Heroes.Animation;


namespace LuckyDefense.Heroes.States
{
    public class HeroIdleState : HeroBaseState
    {
        public HeroIdleState(HeroStateMachine stateMachine) : base(stateMachine)
        {
        }


        public override void Enter()
        {
            base.Enter();

            EventBus.Publish(new HeroStateChangedEvent(Hero, HeroStateType.Idle));
        }

        public override void Update()
        {
            base.Update();

            if (Hero.Combat.TryAcquireTarget())
            {
                stateMachine.ChangeState(stateMachine.Attack);
            }

        }
    }
}

