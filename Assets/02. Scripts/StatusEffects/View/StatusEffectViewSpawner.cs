using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters;
using LuckyDefense.StatusEffects.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.StatusEffects.View
{
    public class StatusEffectViewSpawner : MonoBehaviour
    {
        private readonly Dictionary<Monster, Dictionary<StatusEffectType, StatusEffectView>> activeEffects = new();


        private void Awake()
        {
            EventBus.Subscribe<StatusEffectAddedEvent>(OnStatusAdded);

            EventBus.Subscribe<StatusEffectRemovedEvent>(OnStatusRemoved);

            EventBus.Subscribe<MonsterDeadEvent>(OnMonsterDead);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<StatusEffectAddedEvent>(OnStatusAdded);

            EventBus.Unsubscribe<StatusEffectRemovedEvent>(OnStatusRemoved);

            EventBus.Unsubscribe<MonsterDeadEvent>(OnMonsterDead);
        }

        private void OnStatusAdded(IEvent e)
        {
            StatusEffectAddedEvent evt = (StatusEffectAddedEvent)e;

            Spawn(evt.Monster, evt.Type);
        }

        private void OnStatusRemoved(IEvent e)
        {
            StatusEffectRemovedEvent evt = (StatusEffectRemovedEvent)e;

            Remove(evt.Monster, evt.Type);
        }

        private void OnMonsterDead(IEvent e)
        {
            MonsterDeadEvent evt = (MonsterDeadEvent)e;

            RemoveAll(evt.Monster);
        }


        public void Spawn(Monster monster, StatusEffectType type)
        {
            if (!activeEffects.TryGetValue(monster, out var effectDict))
            {
                effectDict = new();

                activeEffects.Add(monster, effectDict);
            }

            if (effectDict.ContainsKey(type))
                return;


            StatusEffectConfig config = GameManager.Instance.Data.GetStatusEffect(type);

            if (config == null)
                return;

            StatusEffectView view = Object.Instantiate(config.ViewPrefab);

            view.Initialize(monster, type, config.Offset);

            effectDict.Add(type, view);
        }

        public void Remove(Monster monster, StatusEffectType type)
        {
            if (!activeEffects.TryGetValue(monster, out var effectDict))
            {
                return;
            }

            if (!effectDict.TryGetValue(type, out var view))
            {
                return;
            }

            Object.Destroy(view.gameObject);

            effectDict.Remove(type);

            if (effectDict.Count == 0)
            {
                activeEffects.Remove(monster);
            }
        }

        public void RemoveAll(Monster monster)
        {
            if (!activeEffects.TryGetValue(monster, out var effectDict))
            {
                return;
            }

            foreach (var pair in effectDict)
            {
                Object.Destroy(pair.Value.gameObject);
            }

            activeEffects.Remove(monster);
        }
    }
}