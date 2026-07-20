using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Heroes.Runtime
{
    public class OrbitController
    {
        public Hero Owner;

        public float Radius;

        public float RotateSpeed;

        public float Duration;

        public float Damage;

        public float ElapsedTime;

        public float HitInterval = 0.2f;

        public readonly List<Orbit> Orbit = new();

        public bool IsFinished => ElapsedTime >= Duration;

        public OrbitController(Hero hero, float radius, float speed, float duration, float damage)
        {
            Owner = hero;
            Radius = radius;
            RotateSpeed = speed;
            Duration = duration;
            Damage = damage;
        }
    }
}
