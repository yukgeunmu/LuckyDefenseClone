using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using UnityEngine;

namespace LuckyDefense.UI
{
    public class DamageTextSpawner : MonoBehaviour
    {
        [SerializeField]
        private DamageTextView prefab;

        private void Awake()
        {
            EventBus.Subscribe<MonsterDamagedEvent>(
                OnDamage);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<MonsterDamagedEvent>(
                OnDamage);
        }

        private void OnDamage(IEvent e)
        {
            MonsterDamagedEvent evt = (MonsterDamagedEvent)e;

            DamageTextView view = Instantiate(prefab, evt.Position,Quaternion.identity);

            view.Initialize( evt.Damage, evt.Critical);
        }
    }
}