using System;
using System.Collections.Generic;

namespace LuckyDefense.Core
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, Action<IEvent>>
            eventDictionary = new();

        public static void Subscribe<T>(Action<IEvent> callback) where T : IEvent
        {
            Type type = typeof(T);

            if (!eventDictionary.ContainsKey(type))
                eventDictionary[type] = callback;
            else
                eventDictionary[type] += callback;
        }

        public static void Publish(IEvent gameEvent)
        {
            Type type = gameEvent.GetType();

            if (eventDictionary.TryGetValue(type, out var callback))
                callback?.Invoke(gameEvent);
        }
    }
}
