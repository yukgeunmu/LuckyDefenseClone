using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.StatusEffects
{
    public class PoisonEffect : StatusEffect
    {
        private readonly int damage;

        private float tickTimer;

        public override StatusStackType StackType => StatusStackType.Stack;

        public PoisonEffect(Monster monster, float duration, int damage) : base(monster, StatusEffectType.Poison, duration)
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

                GameManager.Instance.Damage.DealDamage( monster, damage);
            }
        }
    }
}