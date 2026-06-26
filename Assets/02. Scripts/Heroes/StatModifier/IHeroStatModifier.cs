using LuckyDefense.Heroes.Data;



namespace LuckyDefense.Heroes.StatModifier
{
    public interface IHeroStatModifier
    {
        void Apply(HeroStats stats);

        void Remove(HeroStats stats);
    }
}
