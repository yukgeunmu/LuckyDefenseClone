
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Skill.Data;

namespace LuckyDefense.Skill.Passive
{
    public class EventPassiveSkill : PassiveSkill
    {
        private Hero owner;

        public EventPassiveSkill(SkillData data) : base(data)
        {
        }

        public override void Apply( Hero hero)
        {
            owner = hero;

            switch (Data.SkillName)
            {
                case "Heist":
                    EventBus.Subscribe <MonsterDeadEvent>(OnMonsterDead);
                    break;
            }
        }

        public override void Remove(Hero hero)
        {
            EventBus.Unsubscribe <MonsterDeadEvent>(OnMonsterDead);
        }

        private void OnMonsterDead(IEvent e)
        {
            if (Data.SkillName == "Heist")
            {
                GameManager.Instance.Goods.AddGold((int)Data.Value);
            }
        }
    }
}