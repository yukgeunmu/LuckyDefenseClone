using LuckyDefense.StatusEffects;
using LuckyDefense.StatusEffects.View;
using UnityEngine;

namespace LuckyDefense.StatusEffects.Data
{
    [CreateAssetMenu(fileName = "StatusEffectData", menuName ="Game/Skill/StatusEffectConfig")]
    public class StatusEffectConfig : ScriptableObject
    {
        public StatusEffectType Type;

        public StatusEffectView ViewPrefab;

        public Vector3 Offset = Vector3.up;
    }
}