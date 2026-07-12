using LuckyDefense.Core.Manager;
using LuckyDefense.Core.Pool;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterView : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Vector3 originalScale;

        public Monster Monster { get; private set; }

        private Color originColor;

        private bool hit;

        private float hitTimer;


        public void Initialize(Monster monster)
        {
            Monster = monster;

            originColor = Color.white;

            originalScale = transform.localScale;

            if (monster.Data.Icon != null)
            {
                spriteRenderer.sprite = monster.Data.Icon;
            }

            transform.position = GameManager.Instance.Path.GetStartPoint().position;

            Monster.Start();
        }


        private void Update()
        {
            Monster.Update();

            transform.position = Monster.Position;

            if (!hit)
                return;

            if (hitTimer > 0)
            {
                hitTimer -= Time.deltaTime;

                if (hitTimer <= 0)
                {
                    hit = false;

                    spriteRenderer.color = originColor;

                    transform.localScale = originalScale;
                }
            }
        }

        public void PlayHit()
        {
            hit = true;
            hitTimer = 0.1f;

            transform.localScale = originalScale * 1.2f;
            spriteRenderer.color = Color.red;
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
        }
    }

}