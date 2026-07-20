using LuckyDefense.Monsters;
using UnityEngine;


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

