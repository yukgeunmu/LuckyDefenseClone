using UnityEngine;

namespace LuckyDefense.Monsters.View
{
    public class MonsterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private static int spawnIndex = 0;

        public Monster Monster { get; private set; }

        public void Initialize(Monster monster)
        {
            Monster = monster;

            if (monster.Data.Icon != null)
            {
                spriteRenderer.sprite = monster.Data.Icon;
            }

            transform.position = new Vector3( spawnIndex * 1.5f,0, 0);

            spawnIndex++;
        }
    }
}