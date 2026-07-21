using LuckyDefense.Board;
using LuckyDefense.Core.Combat;
using LuckyDefense.Heroes.Buff;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.States;
using LuckyDefense.Monsters;
using LuckyDefense.Skill;

namespace LuckyDefense.Heroes
{
    public class Hero
    {
        public HeroData Data { get; }

        public HeroStats Stats { get; }

        public HeroStateMachine StateMachine { get; }

        public HeroSkillComponent SkillComponent { get; set; }

        public HeroCombat Combat { get; set; }
        public HeroBuffController BuffController { get; }

        public int Level { get; private set; } = 1;

        public GridCell CurrentCell
        {
            get;
            internal set;
        }

        public Monster Target;

        public Hero(HeroData data)
        {
            Data = data;

            Stats = new HeroStats(data);

            StateMachine = new HeroStateMachine(this);
        }

        public int HeroID => Data.HeroID;

        public string HeroName => Data.HeroName;

        public HeroGrade Grade => Data.Grade;

        public void Start()
        {
            StateMachine.ChangeState(StateMachine.Idle);
        }

        public void Update()
        {
            StateMachine.Update();
        }

    }
}

