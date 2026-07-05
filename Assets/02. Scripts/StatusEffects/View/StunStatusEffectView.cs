using UnityEngine;


namespace LuckyDefense.StatusEffects.View
{
    public class StunStatusEffectView : StatusEffectView
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


