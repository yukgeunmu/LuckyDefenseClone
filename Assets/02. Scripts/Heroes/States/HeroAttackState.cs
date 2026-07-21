using LuckyDefense.Core.Events;
using LuckyDefense.Heroes.Animation;

namespace LuckyDefense.Heroes.States
{
    public class HeroAttackState : HeroBaseState
    {
        public HeroAttackState(HeroStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            EventBus.Publish(new HeroStateChangedEvent(Hero, HeroStateType.Attack));
        }

        public override void Update()
        {
            if (Hero.Target == null || Hero.Target.IsDead)
            {
                stateMachine.ChangeState(stateMachine.Idle);
                return;
            }

            Hero.Combat.Attack(Hero.Target);
        }
    }
}


