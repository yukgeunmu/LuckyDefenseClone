using LuckyDefense.Monsters;
using Unity.VisualScripting;
using UnityEngine;


namespace LuckyDefense.StatusEffects
{
    public class StatusEffectFactory 
    {
        public StatusEffect Create(Monster monster,float duration,float statusValue ,StatusEffectType type)
        {
            switch (type)
            {
                case StatusEffectType.None:
                    return null;
                case StatusEffectType.Freeze:
                    return new FreezeEffect(monster, duration,  statusValue);
                case StatusEffectType.Stun:
                    return new StunEffect(monster, duration);
                case StatusEffectType.Poison:
                    return new PoisonEffect(monster, duration, (int)statusValue);
                case StatusEffectType.Burn:
                    return new BurnEffect(monster, duration, (int)statusValue);
                default:
                    return null;
            }
        }
    }
}

