using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.Skill
{
    public abstract class ActiveSkill : ISkill
    {
        public Hero Owner
        {
            get;
            private set;
        }

        protected float cooldown;

        private float timer;

        public virtual void Initialize(Hero hero)
        {
            Owner = hero;
        }

        public bool CanCast()
        {
            timer += Time.deltaTime;

            if (timer < cooldown)
                return false;

            timer = 0;

            return true;
        }

        public abstract void Cast(Monster target);
    }
}