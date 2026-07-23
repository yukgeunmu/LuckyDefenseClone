using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Monsters;
using LuckyDefense.Skill.Data;


namespace LuckyDefense.Skill.Active
{
    public class OrbitSkill : ActiveSkill
    {
        public OrbitSkill(SkillDataSO data) : base(data)
        {
        }

        public override void Execute(Hero hero, Monster target)
        {
            if (!CanCast())
                return;

            ResetCooldown();

            float damage = hero.Stats.Attack * Data.Value;

            OrbitController controller = new OrbitController
                (
                    hero,
                    Data.Radius,
                    Data.Speed,
                    Data.Duration,
                    damage
                 );

            float step = 360f / Data.Count;

            for (int i = 0; i < Data.Count; i++)
            {
                controller.Orbit.Add(new Orbit(controller, i * step));
            }

            GameManager.Instance.Orbit.Spawn(controller, Data.OrbitPrefab);

        }
    }

}
