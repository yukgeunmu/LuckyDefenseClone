using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Monsters;
using LuckyDefense.Monsters.Data;
using LuckyDefense.Monsters.Factory;
using System.Collections.Generic;

namespace LuckyDefense.Core.Manager
{
    public class SpawnManager
    {
        private readonly HeroFactory heroFactory;

        private readonly MonsterFactory monsterFactory;

        private readonly List<Monster> monsters = new();

        public IReadOnlyList<Monster> Monsters => monsters;

        public SpawnManager(HeroFactory heroFactory, MonsterFactory monserFactory)
        {
            this.heroFactory = heroFactory;
            this.monsterFactory = monserFactory;
        }

        public bool SummonHero()
        {
            if (!GameManager.Instance.Resource
                    .SpendSilver(GameConst.HeroSummonCost))
            {
                return false;
            }

            HeroData heroData =
                GameManager.Instance.Data
                    .GetRandomCommonHero();

            Hero hero = heroFactory.Create(heroData);

            bool result =
                GameManager.Instance.Placement
                    .PlaceHero(hero);

            if (!result)
            {
                GameManager.Instance.Resource
                    .AddSilver(GameConst.HeroSummonCost);

                return false;
            }

            EventBus.Publish(new HeroSummonedEvent(hero));
            return true;
        }

        public Monster SpawnMonster(MonsterData monsterData)
        {
            Monster monster = monsterFactory.Create(monsterData);

            monsters.Add(monster);

            EventBus.Publish(new MonsterSpawnedEvent(monster));

            return monster;
        }


        public void RemoveMonster(Monster monster)
        {
            monsters.Remove(monster);
        }

        public void ClearMonster()
        {
            monsters.Clear();
        }

        public Hero SpawnHeroTest()
        {
            HeroData heroData = GameManager.Instance.Data.GetRandomCommonHero();

            return heroFactory.Create(heroData);
        }

    }
}