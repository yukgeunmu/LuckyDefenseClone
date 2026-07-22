using Cysharp.Threading.Tasks;
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using System.Threading.Tasks;
using UnityEngine;

namespace LuckyDefense.Skill.View
{
    public class SkillEffectSpawner : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Subscribe< SkillEffectEvent>(OnEffect);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<SkillEffectEvent>(OnEffect);
        }

        private void OnEffect(IEvent e)
        {
            SpawnAsync((SkillEffectEvent)e).Forget();
        }

        private async UniTask SpawnAsync(SkillEffectEvent evt)
        {
            SkillEffectView view = await GameManager.Instance.Pool.Get<SkillEffectView>(evt.EffectPrefab);

            if (view == null)
                return;

            view.transform.localScale =
                Vector3.one *
                evt.Radius;

            view.Initialize(evt);
            view.Play();
        }
    }
}