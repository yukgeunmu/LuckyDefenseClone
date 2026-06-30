using LuckyDefense.Core.Events;
using UnityEngine;

namespace LuckyDefense.Skill.View
{
    public abstract class SkillEffectView : MonoBehaviour
    {
        public virtual void Initialize(SkillEffectEvent evt)
        {
        }

        public abstract void Play();
    }
}