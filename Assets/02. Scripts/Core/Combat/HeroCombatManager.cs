using LuckyDefense.Core.Combat;
using LuckyDefense.Heroes;
using System.Collections.Generic;

namespace LuckyDefense.Core.Combat
{
    public class HeroCombatManager
    {
        private readonly Dictionary<Hero, HeroCombat> combats = new();

        public IReadOnlyDictionary<Hero, HeroCombat> Combats => combats;

        public void Add(Hero hero, ITargetStrategy primary, ITargetStrategy fallback)
        {
            combats.Add(hero, new HeroCombat(hero, primary, fallback));
        }

        public void Remove(Hero hero)
        {
            combats.Remove(hero);
        }

    }
}