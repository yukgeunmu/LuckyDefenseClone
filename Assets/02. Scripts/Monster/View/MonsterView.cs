using LuckyDefense.Core.Manager;
using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public Monster Monster { get; private set; }

        public void Initialize(Monster monster)
        {
            Monster = monster;

            if (monster.Data.Icon != null)
            {
                spriteRenderer.sprite = monster.Data.Icon;
            }

            Transform start =GameManager.Instance.Path.GetStartPoint();

            this.transform.position = start.position;

        }
    }
}