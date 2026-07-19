using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Monsters.View
{
    public class MonsterPresenter : MonoBehaviour
    {

        [SerializeField]
        private AssetReferenceGameObject prefab;

        private void OnEnable()
        {
            EventBus.Subscribe<WaveStartedEvent>(OnWaveStarted);
            EventBus.Subscribe<MonsterSpawnedEvent>(OnMonsterSpawned);
            EventBus.Subscribe<MonsterDeadEvent>(OnMonsterDead);
            EventBus.Subscribe<MonsterDamagedEvent>(OnDamage);
            EventBus.Subscribe<DamageTextExpiredEvent>(OnDamageTextExpire);

        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<WaveStartedEvent>(OnWaveStarted);
            EventBus.Unsubscribe<MonsterSpawnedEvent>(OnMonsterSpawned);
            EventBus.Unsubscribe<MonsterDeadEvent>(OnMonsterDead);
            EventBus.Unsubscribe<MonsterDamagedEvent>(OnDamage);
            EventBus.Unsubscribe<DamageTextExpiredEvent>(OnDamageTextExpire);
        }

        private void OnWaveStarted(IEvent e)
        {
            WaveStartedEvent evt = (WaveStartedEvent)e;

            GameManager.Instance.Spawn.StartWave(evt.Wave);
        }


        private void OnMonsterSpawned(IEvent e)
        {
            SpawnAsync((MonsterSpawnedEvent)e).Forget();
        }

        private async UniTaskVoid SpawnAsync(MonsterSpawnedEvent evt)
        {
            MonsterView view = await GameManager.Instance.Pool.Get<MonsterView>(evt.Monster.Data.ViewPrefab);

            view.Initialize(evt.Monster);

            GameManager.Instance.MonsterView.Add(evt.Monster, view);
        }

        private void OnMonsterDead(IEvent e)
        {
            MonsterDeadEvent evt = (MonsterDeadEvent)e;

            int reward = evt.Monster.Data.RewardGold;

            GameManager.Instance.Goods.AddGold(reward);

            MonsterView view = GameManager.Instance.MonsterView.GetView(evt.Monster);


            if (view != null)
            {
                view.ResetView();
                GameManager.Instance.Pool.Release(view.gameObject);
                GameManager.Instance.MonsterView.Remove(evt.Monster);
                GameManager.Instance.Spawn.OnMonsterDead();
            }

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

        private void OnDamageTextExpire(IEvent e)
        {
            DamageTextExpiredEvent evt = (DamageTextExpiredEvent)e;

            GameManager.Instance.Pool.Release(evt.TextView.gameObject);
        }
    }
}