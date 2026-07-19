using LuckyDefense.Core.Events;
using LuckyDefense.Core.Pool;
using UnityEngine;

namespace LuckyDefense.Skill.View
{
    public abstract class SkillEffectView : MonoBehaviour, IPoolable
    {
        public virtual void Initialize(SkillEffectEvent evt)
        {
        }

        public virtual void OnDespawn()
        {
        }

        public virtual void OnSpawn()
        {
        }

        public abstract void Play();
    }
}