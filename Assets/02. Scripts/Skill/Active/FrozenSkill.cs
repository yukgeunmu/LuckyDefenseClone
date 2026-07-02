using LuckyDefense.Monsters;
using LuckyDefense.StatusEffects;

namespace LuckyDefense.Skill
{
    public class FrozenSkill : ActiveSkill
    {

        private readonly float radius;

        private readonly float value;

        private readonly float duration;


        public FrozenSkill(float cooldown,float radius, float value, float duration)
        {
            this.cooldown = cooldown;
            this.radius = radius;
            this.value = value/100;
            this.duration = duration;
        }

        public override void Cast(Monster target)
        {
            if (target == null)
                return;

            target.Status.AddEffect(new FreezeEffect(target, duration, value));
        }
    }
}