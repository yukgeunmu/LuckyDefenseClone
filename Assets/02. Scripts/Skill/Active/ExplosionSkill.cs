using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.Skill
{
    public class ExplosionSkill : ActiveSkill
    {
        private readonly float radius;

        private readonly int damage;

        public ExplosionSkill(float cooldown, float radius, int damage)
        {
            this.cooldown = cooldown;

            this.radius = radius;

            this.damage = damage;
        }

        public override void Cast(Monster target)
        {

            EventBus.Publish(new SkillEffectEvent(SkillEffectType.Explosion, target.Position, radius));

            foreach (var monster in GameManager.Instance.Spawn.Monsters)
            {
                if (monster.IsDead)
                    continue;

                float distance =
                    Vector3.Distance(
                        target.Position,
                        monster.Position);

                if (distance > radius)
                    continue;

                GameManager.Instance.Damage.DealDamage(Owner, monster, damage);
            }
        }
    }
}