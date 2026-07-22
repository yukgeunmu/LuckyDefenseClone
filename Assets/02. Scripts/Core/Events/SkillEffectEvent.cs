using LuckyDefense.Skill;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Core.Events
{
    public struct SkillEffectEvent : IEvent
    {
        public AssetReferenceGameObject EffectPrefab;

        public Vector3 Position;

        public float Radius;

        public SkillEffectEvent(AssetReferenceGameObject effectPrefab, Vector3 position, float radius = 0)
        {
            EffectPrefab = effectPrefab;
            Position = position;
            Radius = radius;
        }
    }
}