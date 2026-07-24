using UnityEngine;


namespace LuckyDefense.Heroes.Animation
{
    [System.Serializable]
    public class HeroAnimationData
    {
        [SerializeField] 
        private string idleParameterName = "IsIdle";

        [SerializeField] 
        private string attackParameterName = "IsAttack";


        public int IdleParameterHash { get; private set; }
        public int AttackParameterHash { get; private set; }


        public void Init()
        {
            IdleParameterHash = Animator.StringToHash(idleParameterName);
            AttackParameterHash = Animator.StringToHash(attackParameterName);
        }

    }
}

