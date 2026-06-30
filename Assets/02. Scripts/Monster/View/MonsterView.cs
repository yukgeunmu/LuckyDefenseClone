using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Vector3 originalScale;

        public Monster Monster { get; private set; }

        private bool isMoving;

        private bool hit;

        private float hitTimer;


        public void Initialize(Monster monster)
        {
            Monster = monster;

            originalScale = transform.localScale;

            if (monster.Data.Icon != null)
            {
                spriteRenderer.sprite = monster.Data.Icon;
            }

            this.transform.position = GameManager.Instance.Path.GetStartPoint().position;

            isMoving = true;

        }

        private void Update()
        {
            if (!isMoving)
                return;

            Move();

            Monster.Position = transform.position;

            if (!hit)
                return;

            if (hitTimer > 0)
            {
                hitTimer -= Time.deltaTime;

                if (hitTimer <= 0)
                {
                    hit = false;

                    spriteRenderer.color = Color.white;

                    transform.localScale = originalScale;
                }
            }
        }

        private void Move()
        {
            int pathIndex = Monster.CurrentPathIndex;

            Transform target =  GameManager.Instance.Path.GetPoint(pathIndex);

            transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    Monster.Stats.MoveSpeed
                    * Time.deltaTime);

            float distance =
                Vector3.Distance(
                    transform.position,
                    target.position);

            if (distance < 0.05f)
            {
                Monster.MoveNextPath();
            }
        }

        public void PlayHit()
        {
            hit = true;
            hitTimer = 0.1f;

            transform.localScale = originalScale * 1.2f;
            spriteRenderer.color = Color.red;
        }


    }

}