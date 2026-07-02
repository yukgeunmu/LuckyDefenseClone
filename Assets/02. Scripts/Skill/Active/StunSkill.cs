using LuckyDefense.Monsters;
using LuckyDefense.Skill;


namespace LuckyDefense.Skill
{
    public class StunSkill : ActiveSkill
    {
        public override void Cast( Monster target)
        {
            if (target == null)
                return;

            target.Status.AddEffect(new StunEffect(target, 3f));
        }
    }
}
