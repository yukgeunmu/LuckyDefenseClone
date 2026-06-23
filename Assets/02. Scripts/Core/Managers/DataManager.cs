using LuckyDefense.Heroes.Data;
using System.Collections.Generic;

namespace LuckyDefense.Core
{
    public class DataManager
    {
        private Dictionary<int, HeroData> heroDict = new();

        private List<HeroData> commonHeroes = new();

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

                if (hero.Grade == HeroGrade.Common)
                    commonHeroes.Add(hero);
            }

        }

        public HeroData GetHero(int heroID)
        {
            heroDict.TryGetValue(heroID, out HeroData hero);

            return hero;
        }

        public HeroData GetRandomCommonHero()
        {
            int index =
                UnityEngine.Random.Range(
                    0,
                    commonHeroes.Count);

            return commonHeroes[index];
        }
    }
}



