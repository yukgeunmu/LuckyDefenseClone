using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.Heroes.Runtime
{
    public class Projectile
    {
        public Hero Owner { get; }

        public Monster Target { get; }

        public Vector3 Position { get; private set; }

        public float Speed { get; }

        public bool IsDestroyed { get; private set; }

        public Projectile( Hero owner, Monster target, Vector3 position ,float speed)
        {
            Owner = owner;
            Target = target;
            Position = position;
            Speed = speed;
        }

        public void Move(Vector3 pos)
        {
            Position = pos;
        }

        public void Destroy()
        {
            IsDestroyed = true;
        }
    }
}