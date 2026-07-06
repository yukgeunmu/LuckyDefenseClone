using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters
{
    public class MonsterRewardHandler : MonoBehaviour
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

            int reward =  evt.Monster.Data.RewardGold;

            GameManager.Instance.Resource.AddGold(reward);
        }
    }
}