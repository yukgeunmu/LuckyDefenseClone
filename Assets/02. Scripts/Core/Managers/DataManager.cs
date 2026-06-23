using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core
{
    public class DataManager
    {
        private Dictionary<int, HeroData> heroDict = new();

        public void Init(HeroDatabase database)
        {
            heroDict.Clear();

            foreach (HeroData hero in database.Heroes)
            {
                if (heroDict.ContainsKey(hero.HeroID))
                {
                    UnityEngine.Debug.LogError(
                        $"ม฿บน HeroID : {hero.HeroID}");

                    continue;
                }

                heroDict.Add(hero.HeroID, hero);
            }
        }

        public HeroData GetHero(int heroID)
        {
            heroDict.TryGetValue(heroID, out HeroData hero);

            return hero;
        }
    }
}



