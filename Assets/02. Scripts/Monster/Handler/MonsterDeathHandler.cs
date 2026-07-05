using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters.View;
using UnityEngine;

namespace LuckyDefense.Monsters.Handler
{
    public class MonsterDeathHandler : MonoBehaviour
    {

        private void OnEnable()
        {
            EventBus.Subscribe<MonsterDeadEvent>(OnMonsterDead);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<MonsterDeadEvent>(OnMonsterDead);
        }

        private void OnMonsterDead(IEvent e)
        {
            MonsterDeadEvent evt = (MonsterDeadEvent)e;

            MonsterView view = GameManager.Instance.MonsterView.GetView(evt.Monster);

            if (view != null)
            {
                GameManager.Instance.MonsterView.Remove(evt.Monster);
            }
        }
    }
}