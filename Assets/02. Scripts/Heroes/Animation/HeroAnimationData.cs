using UnityEngine;


namespace LuckyDefense.Heroes.Animation
{
    [System.Serializable]
    public class HeroAnimationData
    {

        [SerializeField]
        private string attackTriggerName = "Attack";

        public int AttackTriggerHash { get; private set; }

        public void Init()
        {
            AttackTriggerHash = Animator.StringToHash(attackTriggerName);
        }

    }
}

