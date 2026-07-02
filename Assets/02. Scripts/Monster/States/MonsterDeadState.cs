using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.States
{
    public class MonsterDeadState : MonsterBaseState
    {
        private float timer;

        public MonsterDeadState(MonsterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Publish(new MonsterDeadEvent(Monster));
        }

    }
}


