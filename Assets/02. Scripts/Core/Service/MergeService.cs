using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using System.Collections.Generic;

namespace LuckyDefense.Core.Service
{
    public class MergeService
    {
        public HeroMergeService HeroMergeService { get; private set; }
        public RecipeService RecipeService { get; private set; }

        private HeroFactory heroFactory;

        public MergeService(HeroFactory heroFactory)
        {
            this.HeroMergeService = new(this);
            this.RecipeService = new(this);
            this.heroFactory = heroFactory;
        }

        public Hero SpawnResultHero(HeroDataSO data, IReadOnlyList<Hero> consumes)
        {
            Hero hero = heroFactory.Create(data);

            GameManager.Instance.Placement.PlaceHero(hero);

            EventBus.Publish(new HeroMergedEvent(hero, consumes));

            EventBus.Publish(new HeroSummonedEvent(hero));

            return hero;
        }

    }
}