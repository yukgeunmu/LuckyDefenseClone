using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.StatusEffects
{
    public class FreezeEffect : StatusEffect
    {
        private readonly float slowPercent;

        public override StatusStackType StackType => StatusStackType.MaxDuration;

        public FreezeEffect( Monster monster, float duration, float slowPercent) : base( monster, StatusEffectType.Freeze, duration)
        {
            this.slowPercent = slowPercent;
        }

        public override void Enter()
        {
            base.Enter();

            monster.SpeedModifier *=  slowPercent;
        }

        public override void Exit()
        {
            monster.SpeedModifier /= slowPercent;

            base.Exit();
        }

        public override void Refresh(StatusEffect other)
        {
            Duration = Mathf.Max( Duration, other.Duration);
        }
    }
}