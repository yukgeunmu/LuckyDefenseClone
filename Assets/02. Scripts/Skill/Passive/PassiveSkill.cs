using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;
using NUnit.Framework.Internal.Commands;

namespace LuckyDefense.Skill.Passive
{

    /*
        항상 적용
        이벤트 구독 가능
        공격 시 발동 가능
        처치 시 발동 가능  
        버프 적용 가능
     */
    public abstract class PassiveSkill: ISkill
    {
        public SkillData Data { get; }

        public SkillCategory SkillType => SkillCategory.Passive;
        protected PassiveSkill(SkillData data)
        {
            this.Data = data;
        }

        /// 영웅 배치 시 호출
        /// </summary>
        public abstract void Apply(Hero hero);

        /// <summary>
        /// 영웅 제거 시 호출
        /// </summary>
        public virtual void Remove(Hero hero)
        {
        }

        public virtual int ModifyDamage(Hero hero, int damage)
        {
            return damage;
        }
    }
}