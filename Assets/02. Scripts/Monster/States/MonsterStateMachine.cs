using System.Collections.Generic;

namespace LuckyDefense.Monsters.States
{
    public class MonsterStateMachine : StateMachine
    {
        public Monster Monster { get; }
        public MonsterMoveState MoveState { get; private set; }

        public MonsterStunState StunState { get; private set; }

        public MonsterDeadState DeadState { get; private set; }
        public MonsterStateMachine(Monster monster)
        {
            Monster = monster;

            MoveState = new MonsterMoveState(this);
            DeadState = new MonsterDeadState(this);
            StunState = new MonsterStunState(this);
        }

        public void ChangeState( MonsterBaseState state)
        {

             state.Exit();
           
            currentState = state;

            currentState?.Enter();
        }


        public void Stun(float duration)
        {
            StunState.SetDuration(duration);

            ChangeState(StunState);
        }

        public void Dead()
        {
            ChangeState(DeadState);
        }
    }
}