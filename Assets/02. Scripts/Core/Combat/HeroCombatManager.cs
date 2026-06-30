using LuckyDefense.Heroes;
using System.Collections.Generic;

namespace LuckyDefense.Core.Combat
{
    public class HeroCombatManager
    {
        private readonly Dictionary<Hero, HeroCombat> combats = new();

        public IReadOnlyDictionary<Hero, HeroCombat> Combats => combats;

        public void Add(Hero hero)
        {
            combats.Add(hero, hero.Combat);
        }

        public void Remove(Hero hero)
        {
            combats.Remove(hero);
        }

    }
}