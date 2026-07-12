using Cysharp.Threading.Tasks;
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.UI
{
    public class DamageTextSpawner : MonoBehaviour
    {
        [SerializeField]
        private AssetReferenceGameObject prefab;

        private void Start()
        {
            GameManager.Instance.Pool.Prewarm<DamageTextView>(prefab, 20).Forget();
        }

        private void Awake()
        {
            EventBus.Subscribe<MonsterDamagedEvent>(OnDamage);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<MonsterDamagedEvent>(OnDamage);
        }



        private void OnDamage(IEvent e)
        {
            SpawnAsync((MonsterDamagedEvent)e).Forget();
        }


        private async UniTask SpawnAsync(MonsterDamagedEvent evt)
        {
            DamageTextView view = await GameManager.Instance.Pool.Get<DamageTextView>(prefab);

            view.transform.SetLocalPositionAndRotation(evt.Position, Quaternion.identity);

            view.Initialize(evt.Damage, evt.Critical);
        }
    }
}