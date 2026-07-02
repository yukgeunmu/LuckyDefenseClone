using LuckyDefense.Monsters;
using UnityEngine;

namespace LuckyDefense.StatusEffects.View
{
    public abstract class StatusEffectView : MonoBehaviour
    {
        protected Monster monster;

        protected Vector3 offset;

        public StatusEffectType Type { get;  protected set;}

        public virtual void Initialize( Monster monster, StatusEffectType type, Vector3 offset)
        {
            this.monster = monster;
            this.offset = offset;

            Type = type;

           
        }

        protected virtual void Update()
        {
            if (monster == null)
            {
                Destroy(gameObject);
                return;
            }

            transform.position = monster.Position;
        }

        public virtual void Play()
        {
        }

        public virtual void Stop()
        {
        }
    }
}