using LuckyDefense.Skill.Data;
using LuckyDefense.Skill.Passive;
using LuckyDefense.StatusEffects;
using System;


namespace LuckyDefense.SheetData
{
    [Serializable]
    public class SkillData
    {
        public int SkillID;

        public string SkillName;

        public SkillCategory Category;

        public SkillClass SkillClass;

        public StatusEffectType StatusEffectType;

        public SkillLogicType LogicType;

        public float Value;

        public float StatusEffectValue;

        public float Radius;

        public float Duration;

        public int Cooldown;

        public int Count;

        public float Speed;
    }
}

