using LuckyDefense.Heroes;
using LuckyDefense.Monsters;

namespace LuckyDefense.Skill.Passive
{
    public abstract class PassiveSkill: ISkill
    {
        public Hero Owner
        {
            get;
            private set;
        }

        public virtual void Initialize(Hero hero)
        {
            Owner = hero;
        }

        public abstract int ModifyDamage(Monster target, int damage);
    }
}