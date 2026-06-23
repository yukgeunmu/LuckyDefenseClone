using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;

namespace LuckyDefense.Core
{
    public class SpawnManager
    {
        private readonly HeroFactory heroFactory;

        public SpawnManager()
        {
            heroFactory = new HeroFactory();
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

            Hero hero =
                heroFactory.Create(heroData);

            bool result =
                GameManager.Instance.Board
                    .PlaceHero(hero);

            if (!result)
            {
                GameManager.Instance.Resource
                    .AddSilver(GameConst.HeroSummonCost);

                return false;
            }

            EventBus.Publish(
                new HeroSummonedEvent(hero));

            return true;
        }
    }
}