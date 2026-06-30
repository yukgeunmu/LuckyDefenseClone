using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;

public class SkillService
{
    public void Update()
    {
        foreach (var cell in GameManager.Instance.Board.Cells)
        {
            foreach (var hero in cell.Heroes)
            {
                foreach (var skill in hero.SkillComponent.ActiveSkills)
                {
                    if (!skill.CanCast())
                        continue;

                    Monster target = FindTarget(hero);

                    if (target == null)
                        continue;

                    skill.Cast(target);
                }
            }
        }
    }

    private Monster FindTarget(Hero hero)
    {

        if (!GameManager.Instance.HeroCombat.Combats.TryGetValue(hero, out var combat))
        {
            return null;
        }

        Monster target = combat.FindTarget();
        return target;
    }
}