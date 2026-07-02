using LuckyDefense.Core.Events;
using LuckyDefense.Monsters;

namespace LuckyDefense.StatusEffects
{
    public abstract class StatusEffect
    {
        public StatusEffectType Type { get; }

        public abstract StatusStackType StackType { get; }

        public float Duration { get; protected set; }

        public bool IsFinished => Duration <= 0;

        protected readonly Monster monster;

        protected StatusEffect(Monster monster, StatusEffectType type, float duration)
        {
            this.monster = monster;
            Type = type;
            Duration = duration;
        }

        public virtual void Enter()
        {
            EventBus.Publish(new StatusEffectAddedEvent(monster,Type));
        }

        public virtual void Update()
        {
            Duration -= UnityEngine.Time.deltaTime;
        }

        public virtual void Exit()
        {
            EventBus.Publish(new StatusEffectRemovedEvent(monster, Type));
        }

        public virtual void Refresh(StatusEffect other)
        {
        }
    }
}