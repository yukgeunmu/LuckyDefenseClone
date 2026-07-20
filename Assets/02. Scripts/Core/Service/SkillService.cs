using LuckyDefense.Core.Manager;

public class SkillService
{
    public void Update()
    {
        foreach (var cell in GameManager.Instance.Board.Cells)
        {
            foreach (var hero in cell.Heroes)
            {
                if (hero.Combat.FindTarget(out var target))
                {
                    foreach (var skill in hero.SkillComponent.ActiveSkills)
                    {
                        skill.Execute(hero, target);
                    }
                }
            }
        }
    }

}