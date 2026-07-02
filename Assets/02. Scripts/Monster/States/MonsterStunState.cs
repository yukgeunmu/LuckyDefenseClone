using UnityEngine;

namespace LuckyDefense.Monsters.States
{
    public class MonsterStunState : MonsterBaseState
    {

        private float duration;

        public MonsterStunState(MonsterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public void SetDuration(float duration)
        {
            this.duration = Mathf.Max(this.duration, duration);
        }

        public override void Enter()
        {
            Debug.Log($"{Monster.Data.name} Stun");
        }

        public override void Update()
        {
            duration -= Time.deltaTime;

            if (duration <= 0)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }
        }

        public override void Exit()
        {
            Debug.Log($"{Monster.Data.name} Stun End");
        }
    }
}