using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.StatusEffects
{
    public class BurnEffect : StatusEffect
    {
        private readonly int damage;
        private float tickTimer;

        public override StatusStackType StackType => StatusStackType.MaxDuration;

        public BurnEffect( Monster monster, float duration, int damage) : base(monster, StatusEffectType.Burn,  duration)
        {
            this.damage = damage;
        }

        public override void Update()
        {
            base.Update();

            tickTimer += Time.deltaTime;

            if (tickTimer >= 1f)
            {
                tickTimer = 0f;

                GameManager.Instance.Damage.DealDamage(monster, damage);
            }
        }

        public override void Refresh(StatusEffect other)
        {
            Duration = Mathf.Max(Duration, other.Duration);
        }
    }
}