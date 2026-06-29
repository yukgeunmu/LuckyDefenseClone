using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
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


        Hero hero = GameManager.Instance.Spawn.SpawnHeroTest();



        while (!monster.IsDead)
        {
            DamageResult result = GameManager.Instance.Damage.DealDamage(hero, monster);

            Debug.Log(
                monster.Stats.CurrentHP);
        }
    }


}
