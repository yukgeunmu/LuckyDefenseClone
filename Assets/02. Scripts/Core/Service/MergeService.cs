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
        public HeroMergeService TripleMergeService { get; private set; }
        public RecipeService RecipeService { get; private set; }

        private HeroFactory heroFactory;

        public MergeService(HeroFactory heroFactory)
        {
            this.TripleMergeService = new(this, heroFactory);
            this.RecipeService = new(this, heroFactory);
            this.heroFactory = heroFactory;
        }

        public Hero SpawnResultHero(HeroData data, IReadOnlyList<Hero> consumes)
        {
            Hero hero = heroFactory.Create(data);

            GameManager.Instance.Placement.PlaceHero(hero);
            GameManager.Instance.HeroCombat.Add(hero);

            EventBus.Publish(
                new HeroMergedEvent(hero, consumes));

            EventBus.Publish(
                new HeroSummonedEvent(hero));

            return hero;
        }

    }
}