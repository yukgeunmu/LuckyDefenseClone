using LuckyDefense.Monsters.States;



namespace LuckyDefense.Monsters.States
{
    public class MonsterMoveState : MonsterBaseState
    {
        public MonsterMoveState(MonsterStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Update()
        {
            Monster.Move();
        }
    }
}
