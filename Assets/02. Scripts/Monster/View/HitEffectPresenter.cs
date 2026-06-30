using LuckyDefense.Core;
using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class HitEffectPresenter : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.Subscribe<HitEvent>(OnHit);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<HitEvent>(OnHit);
        }

        private void OnHit(IEvent e)
        {
            HitEvent evt =
                (HitEvent)e;

            MonsterView view = GameManager.Instance.MonsterView.GetView(evt.Monster);

            if (view == null)
                return;

            view.PlayHit();
        }
    }
}