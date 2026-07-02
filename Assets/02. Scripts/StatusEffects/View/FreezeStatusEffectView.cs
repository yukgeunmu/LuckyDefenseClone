using UnityEngine;

namespace LuckyDefense.StatusEffects.View
{
    public class FreezeStatusEffectView : StatusEffectView
    {
        [SerializeField]
        private ParticleSystem particle;

        public override void Play()
        {
            particle?.Play();
        }

        public override void Stop()
        {
            particle?.Stop();
        }
    }
}