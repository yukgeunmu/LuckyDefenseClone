using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters.Data;
using LuckyDefense.Monsters.States;
using LuckyDefense.StatusEffects;
using UnityEngine;

namespace LuckyDefense.Monsters
{
    public class Monster
    {
        public MonsterData Data { get; }

        public MonsterStats Stats { get; }

        public MonsterStatusComponent Status { get; }

        public MonsterStateMachine StateMachine { get; }

        public float SpeedModifier { get; set; } = 1f;

        public Vector3 Position { get; set; }

        public bool IsBoss => Data.Type == MonsterType.Boss;

        public bool IsDead => Stats.CurrentHP <= 0;


        public float HPPercent
        {
            get
            {
                return
                    (float)Stats.CurrentHP
                    / Stats.MaxHP;
            }
        }

        //public bool IsDead => Stats.CurrentHP <= 0;

        public int CurrentPathIndex { get; set; }

        public Monster(MonsterData data)
        {
            Data = data;

            Stats = new MonsterStats(data);

            Status = new MonsterStatusComponent(this);

            this.StateMachine = new MonsterStateMachine(this);

            CurrentPathIndex = 1;
        }

        public void Start()
        {
            StateMachine.ChangeState(StateMachine.MoveState);
            Position = GameManager.Instance.Path.GetStartPoint().position;
        }

        public void Update()
        {
            Status.Update();

            StateMachine.Update();
        }

        public void Move()
        {
            Transform target = GameManager.Instance.Path.GetPoint(CurrentPathIndex);

            Position = Vector3.MoveTowards(
                    Position,
                    target.position,
                    Stats.MoveSpeed
                    * SpeedModifier
                    * Time.deltaTime);

            float distance =
                Vector3.Distance(
                    Position,
                    target.position);

            if (distance < 0.05f)
            {
                MoveNextPath();
            }
        }

        public void TakeDamage(int damage)
        {
            Stats.CurrentHP -= damage;

            if (Stats.CurrentHP < 0)
                Stats.CurrentHP = 0;
        }

        public void Heal(int amount)
        {
            Stats.CurrentHP += amount;

            if (Stats.CurrentHP > Stats.MaxHP)
                Stats.CurrentHP = Stats.MaxHP;
        }

        public void MoveNextPath()
        {
            if (CurrentPathIndex >= GameManager.Instance.Path.Count)
                CurrentPathIndex = 0;
            else
                CurrentPathIndex++;
        }
    }
}