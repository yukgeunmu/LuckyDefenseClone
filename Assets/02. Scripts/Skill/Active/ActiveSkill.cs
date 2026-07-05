using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;
using LuckyDefense.StatusEffects;
using System;
using UnityEngine;

namespace LuckyDefense.Skill
{
    /*
        쿨타임 존재
        직접 시전
        타겟 존재
     */
    public abstract class ActiveSkill : ISkill
    {
        public SkillData Data { get; }

        public SkillCategory SkillType => SkillCategory.Active;

        private float lastCastTime = -9999.0f;
        protected ActiveSkill(SkillData data)
        {
            this.Data = data;
        }

        protected bool CanCast()
        {

            return Time.time >= lastCastTime + Data.Cooldown;
        }

        protected void ResetCooldown()
        {
            lastCastTime = Time.time;
        }

        public abstract void Execute(Hero hero, Monster target);

        protected void AddStatusEffect(Hero hero, Monster target)
        {
            switch (Data.StatusEffectType)
            {
                case StatusEffectType.None:
                    return;
                case StatusEffectType.Freeze:
                    target.Status.AddEffect(new FreezeEffect(target, Data.Duration, Data.StatusEffectValue));
                    break;
                case StatusEffectType.Stun:
                    break;
                case StatusEffectType.Poison:
                    break;
            }
        }
    }
}