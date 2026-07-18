using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Monsters;
using LuckyDefense.Monsters.Data;
using LuckyDefense.Monsters.Factory;
using LuckyDefense.Wave.Data;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Core.Manager
{
    public class SpawnManager
    {
        private readonly HeroFactory heroFactory;

        private readonly MonsterFactory monsterFactory;

        private readonly List<Monster> monsters = new();

        public IReadOnlyList<Monster> Monsters => monsters;

        public int AliveMonsterCount;

        private readonly Queue<MonsterData> spawnQueue = new();

        private float spawnTimer;

        private float spawnInterval;

        public bool IsSpawnFinished { get; private set; }

        public SpawnManager(HeroFactory heroFactory, MonsterFactory monsterFactory)
        {
            this.heroFactory = heroFactory;
            this.monsterFactory = monsterFactory;
        }

        public bool SummonHero(HeroGrade grade)
        {
            int price = GameConst.HeroSummonCost;

            if (!GameManager.Instance.Goods.SpendGold(price))
            {
                return false;
            }

            HeroData heroData =
                GameManager.Instance.Data.GetRandomHero(grade); ;


            Hero hero = heroFactory.Create(heroData);

            bool result = GameManager.Instance.Placement.PlaceHero(hero);

            if (!result)
            {
                GameManager.Instance.Goods.AddGold(GameConst.HeroSummonCost);

                return false;
            }
            else
            {
                GameManager.Instance.HeroCombat.Add(hero);
            }



            EventBus.Publish(new HeroSummonedEvent(hero));
            return true;
        }

        public Monster SpawnMonster(MonsterData monsterData)
        {
            Monster monster = monsterFactory.Create(monsterData);

            AliveMonsterCount++;

            monsters.Add(monster);

            EventBus.Publish(new MonsterSpawnedEvent(monster));

            return monster;
        }

        public void RemoveDeadMonsters()
        {
            for (int i = monsters.Count - 1; i >= 0; i--)
            {
                if (monsters[i].IsDead)
                {
                    monsters.RemoveAt(i);
                }
            }
        }


        public void ClearMonster()
        {
            monsters.Clear();
        }


        public void StartWave(WaveData wave)
        {
            spawnQueue.Clear();

            foreach (var info in wave.Monsters)
            {
                for (int i = 0; i < info.Count; i++)
                {
                    spawnQueue.Enqueue(info.Monster);
                }
            }

            spawnInterval = wave.SpawnInterval;

            spawnTimer = 0f;

            IsSpawnFinished = false;
        }

        public void Update()
        {
            if (IsSpawnFinished)
                return;

            spawnTimer += Time.deltaTime;

            if (spawnTimer < spawnInterval)
                return;

            spawnTimer = 0f;

            if (spawnQueue.Count > 0)
            {
                SpawnMonster(spawnQueue.Dequeue());
            }

            if (spawnQueue.Count == 0)
            {
                IsSpawnFinished = true;
            }
        }

    }
}