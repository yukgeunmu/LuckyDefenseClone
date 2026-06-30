using LuckyDefense.Monsters;
using System.Runtime.ConstrainedExecution;
using UnityEngine;


namespace LuckyDefense.Core.Events
{
    public struct MonsterDamagedEvent : IEvent
    {
        public Monster Monster;

        public int Damage;

        public bool Critical;

        public Vector3 Position;

        public MonsterDamagedEvent(Monster monster, int damage, bool critical, Vector3 position)
        {
            Monster = monster;
            Damage = damage;
            Critical = critical;
            Position = position;
        }
    }
}