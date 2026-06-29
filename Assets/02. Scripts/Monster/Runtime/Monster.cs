using LuckyDefense.Monsters.Data;
using LuckyDefense.Core.Manager;
using LuckyDefense.Core.Events;
using UnityEngine;

namespace LuckyDefense.Monsters
{
    public class Monster
    {
        public MonsterData Data { get; }

        public MonsterStats Stats { get; }

        public Vector3 Position{ get;set; }

        public float HPPercent
        {
            get
            {
                return
                    (float)Stats.CurrentHP
                    / Stats.MaxHP;
            }
        }

        public bool IsDead => Stats.CurrentHP <= 0;

        public int CurrentPathIndex { get; set; }

        public Monster(MonsterData data)
        {
            Data = data;

            Stats = new MonsterStats(data);

            CurrentPathIndex = 1;
        }

        public void TakeDamage(int damage)
        {
            Stats.CurrentHP -= damage;

            Debug.Log(Stats.CurrentHP);

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