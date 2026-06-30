using LuckyDefense.Core;
using LuckyDefense.Core.Events;
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
            SkillEffectEvent evt = (SkillEffectEvent)e;

            SkillEffectView view =
                factory.Create(
                    evt.Type,
                    evt.Position);

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