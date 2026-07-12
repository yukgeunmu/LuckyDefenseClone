using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;
using System;
using UnityEngine;

namespace LuckyDefense.Heroes.Runtime
{
    public class Projectile
    {
        public Hero Owner { get; }

        public Monster Target { get; }
        public Vector3 Position { get; private set; }

        public float Speed { get; }

        public Action<Projectile> OnHit;

        public ProjectileType SkillProjectileType { get; }

        public bool IsReady { get; private set; }

        public bool IsDestroyed { get; private set; }


        public Projectile(
            Hero owner, 
            Monster target, 
            Vector3 position ,
            float speed,
            ProjectileType skillProjectileType = ProjectileType.None)
        {
            Owner = owner;
            Target = target;
            Position = position;
            Speed = speed;
            SkillProjectileType = skillProjectileType;
        }

        public void Move(Vector3 pos)
        {
            Position = pos;
        }

        public void Hit()
        {
            OnHit?.Invoke(this);
        }

        public void Ready()
        {
            IsReady = true;
        }

        public void Destroy()
        {
            IsDestroyed = true;
        }
    }
}