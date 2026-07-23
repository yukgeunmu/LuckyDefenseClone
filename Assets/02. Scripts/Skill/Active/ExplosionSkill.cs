
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;
using UnityEngine;

namespace LuckyDefense.Skill.Active
{
    public class ExplosionSkill : ActiveSkill
    {
        public ExplosionSkill(SkillDataSO data) : base(data)
        {
        }

        public override void Execute(Hero hero, Monster target)
        {
            if (!CanCast())
                return;

            ResetCooldown();

            foreach (var monster in GameManager.Instance.Spawn.Monsters)
            {
                if (monster.IsDead)
                    continue;

                if (Vector3.Distance(monster.Position, target.Position) > Data.Radius)
                    continue;

                GameManager.Instance.Damage.DealDamage(monster, (int)Data.Value);

            }

            EventBus.Publish(new SkillEffectEvent(Data.EffectPrefab, target.Position, Data.Radius));
        }
    }
}