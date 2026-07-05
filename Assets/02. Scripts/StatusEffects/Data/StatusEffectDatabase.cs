using LuckyDefense.StatusEffects.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.StatusEffects.Data
{
    [CreateAssetMenu( menuName = "Game/Skill/StatusEffectDatabase", fileName = "StatusEffectDatabase")]
    public class StatusEffectDatabase : ScriptableObject
    {
        public List<StatusEffectConfig> Effects = new();
    }
}