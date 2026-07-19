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

        private SkillEffectFactory factory;


        private void Awake()
        {
            factory = new SkillEffectFactory();

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
            SkillEffectConfig data = GameManager.Instance.Data.GetSkillEffect(evt.Type);

            SkillEffectView view = await GameManager.Instance.Pool.Get<SkillEffectView>(data.ViewPrefab);

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