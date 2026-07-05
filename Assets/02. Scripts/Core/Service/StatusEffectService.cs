
using LuckyDefense.Monsters;
using LuckyDefense.StatusEffects;
using Unity.VisualScripting;

namespace LuckyDefense.Core.Service
{
    public class StatusEffectService
    {
        private StatusEffectFactory factory = new();

        public void Apply(Monster target, StatusEffectType type, float duration, float statusValue)
        {
            StatusEffect effect = factory.Create( target, duration, statusValue, type);

            target.Status.AddEffect(effect);
        }
    }
}