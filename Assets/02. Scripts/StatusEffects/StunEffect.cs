using LuckyDefense.Monsters;
using LuckyDefense.StatusEffects;
using UnityEngine;

public class StunEffect : StatusEffect
{
    public override
    StatusStackType StackType => StatusStackType.MaxDuration;

    public StunEffect(Monster monster, float duration): base(monster, StatusEffectType.Stun, duration)
    {
    }

    public override void Enter()
    {
        monster.StateMachine.Stun(Duration);
    }

    public override void Refresh(StatusEffect other)
    {
        Duration = Mathf.Max(Duration,other.Duration);

        monster.StateMachine.Stun(Duration);
    }
}