using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Skill.View
{
    public class SkillEffectFactory
    {
        public SkillEffectView Create( SkillEffectType type, Vector3 position)
        {
            SkillEffectData data =
                GameManager.Instance
                    .Data
                    .GetSkillEffect(type);

            if (data == null)
                return null;

            return Object.Instantiate(
                data.Prefab,
                position,
                Quaternion.identity);
        }
    }
}