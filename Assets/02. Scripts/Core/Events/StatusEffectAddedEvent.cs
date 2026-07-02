using LuckyDefense.Monsters;
using LuckyDefense.StatusEffects;

namespace LuckyDefense.Core.Events
{
    public class StatusEffectAddedEvent : IEvent
    {
        public Monster Monster { get; }

        public StatusEffectType Type { get; }

        public StatusEffectAddedEvent(Monster monster, StatusEffectType type)
        {
            Monster = monster;
            Type = type;
        }
    }
}