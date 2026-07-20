using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;
using UnityEngine;

namespace LuckyDefense.Heroes.Runtime
{
    public class Orbit
    {
        public OrbitController Controller;

        public float Angle;

        public float LastHitTime;

        public OrbitType Type;

        public Vector3 Position
        {
            get
            {
                float rad = Angle * Mathf.Deg2Rad;

                return Controller.Owner.CurrentCell.WorldPosition +
                       new Vector3(
                           Mathf.Cos(rad),
                           Mathf.Sin(rad),
                           0f) *
                       Controller.Radius;
            }
        }

        public Orbit(OrbitController controller, float angle, OrbitType type)
        {
            Controller = controller;
            Angle = angle;
            Type = type;
        }

        public void Hit(Monster monster)
        {
            if (monster == null)
                return;

            if (monster.IsDead)
                return;

            if (Time.time < LastHitTime + Controller.HitInterval)
                return;

            LastHitTime = Time.time;

            GameManager.Instance.Damage.DealDamage(
                monster,
                (int)Controller.Damage);
        }
    }
}
