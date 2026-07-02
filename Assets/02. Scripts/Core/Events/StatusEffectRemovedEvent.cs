using LuckyDefense.Core;
using LuckyDefense.Monsters;
using LuckyDefense.StatusEffects;

namespace LuckyDefense.Core.Events
{
    public class StatusEffectRemovedEvent : IEvent
    {
        public Monster Monster { get; }

        public StatusEffectType Type { get; }

        public StatusEffectRemovedEvent(Monster monster, StatusEffectType type)
        {
            Monster = monster;
            Type = type;
        }
    }
}