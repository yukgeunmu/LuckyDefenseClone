using LuckyDefense.Skill;
using UnityEngine;

namespace LuckyDefense.Core.Events
{
    public struct SkillEffectEvent : IEvent
    {
        public SkillEffectType Type;

        public Vector3 Position;

        public float Radius;

        public SkillEffectEvent(SkillEffectType type, Vector3 position, float radius = 0)
        {
            Type = type;
            Position = position;
            Radius = radius;
        }
    }
}