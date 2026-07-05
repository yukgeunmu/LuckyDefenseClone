using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.StatusEffects
{
    public class StunEffect : StatusEffect
    {
        public override StatusStackType StackType => StatusStackType.MaxDuration;

        public StunEffect( Monster monster, float duration) : base( monster, StatusEffectType.Stun, duration)
        {
        }

        public override void Enter()
        {
            base.Enter();

            monster.StateMachine.Stun(Duration);
        }


        public override void Refresh( StatusEffect other)
        {
            monster.StateMachine.StunState.SetDuration(other.Duration);
        }
    }
}