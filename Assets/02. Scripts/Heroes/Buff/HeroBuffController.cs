using LuckyDefense.Heroes.StatModifier;
using System.Collections.Generic;



namespace LuckyDefense.Heroes.Buff
{
    public class HeroBuffController
    {
        private readonly List<IHeroStatModifier> modifiers
            = new();

        private readonly Hero hero;

        public HeroBuffController(Hero hero)
        {
            this.hero = hero;
        }

        public void AddModifier(IHeroStatModifier modifier)
        {
            modifiers.Add(modifier);

            modifier.Apply(hero.Stats);
        }
    }
}
