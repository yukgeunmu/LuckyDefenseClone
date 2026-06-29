using LuckyDefense.Heroes;
using LuckyDefense.Monsters;

namespace LuckyDefense.Core.Combat
{
    public interface ITargetStrategy
    {
        Monster FindTarget(Hero hero);
    }
}