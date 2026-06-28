using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public Monster Monster { get; private set; }

        private bool isMoving;

        public void Initialize(Monster monster)
        {
            Monster = monster;

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

    }

}