using LuckyDefense.Heroes.Data;

namespace LuckyDefense.Heroes.Factory
{
    public class HeroFactory
    {
        public Hero Create(HeroData heroData)
        {
            return new Hero(heroData);
        }
    }
}