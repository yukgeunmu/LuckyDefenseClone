using LuckyDefense.Core.Manager;
using LuckyDefense.Monsters;
using UnityEngine;

public class MonsterDamageTest : MonoBehaviour
{
    void Start()
    {
        Monster monster = GameManager.Instance.Spawn.SpawnMonster(
            GameManager.Instance
                .Data
                .GetMonster(1000));

        Debug.Log(monster.Stats.CurrentHP);

        monster.TakeDamage(30);

        Debug.Log(monster.Stats.CurrentHP);

        monster.TakeDamage(100);

        Debug.Log(monster.Stats.CurrentHP);

        Debug.Log( monster.IsDead);
    }


}
