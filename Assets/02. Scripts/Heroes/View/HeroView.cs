using LuckyDefense.Core.Pool;
using LuckyDefense.Heroes.Animation;
using UnityEngine;

namespace LuckyDefense.Heroes.View
{
    public class HeroView : MonoBehaviour, IPoolable
    {
        public Hero Hero { get; private set; }

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private HeroAnimationData animationData;

        [SerializeField]
        private float AttackAnimationLength = 1.125f;

        private Vector3 originalPosition;
        private Transform originalParent;

        public void Init(Hero hero)
        {
            Hero = hero;

            gameObject.name =
                $"{hero.HeroName}";

            animationData.Init();

            switch (hero.Grade)
            {
                case Data.HeroGrade.Common:
                    spriteRenderer.color = Color.white;
                    break;
                case Data.HeroGrade.Rare:
                    spriteRenderer.color = Color.blue;
                    break;
                case Data.HeroGrade.Epic:
                    spriteRenderer.color = Color.violet;
                    break;
                case Data.HeroGrade.Legendary:
                    spriteRenderer.color = Color.yellowNice;
                    break;
                case Data.HeroGrade.Mythic:
                    spriteRenderer.color = Color.blueViolet;
                    break;
            }

        }


        public void PlayIdle()
        {
        }

        public void PlayAttack()
        {
            spriteRenderer.flipX =  Hero.Target.Position.x < Hero.CurrentCell.WorldPosition.x;

            animator.speed = AttackAnimationLength / (1.0f / Hero.Stats.AttackSpeed);

            animator.SetTrigger(animationData.AttackTriggerHash);
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
            Hero = null;

            transform.SetParent(null);
        }
    }
}