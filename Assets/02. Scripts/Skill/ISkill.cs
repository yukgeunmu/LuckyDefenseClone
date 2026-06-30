using LuckyDefense.Heroes;

namespace LuckyDefense.Skill
{
    public interface ISkill
    {
        Hero Owner { get; }

        public void Initialize(Hero hero);

    }
}