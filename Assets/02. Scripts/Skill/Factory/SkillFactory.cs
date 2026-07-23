using LuckyDefense.Skill.Active;
using LuckyDefense.Skill.Data;
using LuckyDefense.Skill.Passive;
using System;
using System.Collections.Generic;

namespace LuckyDefense.Skill
{
    public class SkillFactory
    {
        private Dictionary<SkillClass, Func<SkillDataSO, ISkill>> registry
            = new()
            {
                {SkillClass.StatPassive, d => new StatPassiveSkill(d)},
                {SkillClass.EventPassive, d => new EventPassiveSkill(d)},
                {SkillClass.Projectile, d => new ProjectileSkill(d)},
                {SkillClass.Explosion, d => new ExplosionSkill(d)},
                {SkillClass.Summon, d => new SummonSkill(d) },
                {SkillClass.Aura, d => new AuraSkill(d)},
                {SkillClass.Orbit, d => new OrbitSkill(d)}
            };

        public ISkill Create(SkillDataSO data)
        {
            if (registry.TryGetValue(data.SkillClass, out var creator))
                return creator(data);

            return null;
        }
    }
}