using LuckyDefense.Board;
using LuckyDefense.Board.View;
using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.View;

namespace LuckyDefense.Core.Manager
{
    public class SpawnManager
    {
        private readonly HeroFactory heroFactory;

        public SpawnManager(HeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
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


    }
}