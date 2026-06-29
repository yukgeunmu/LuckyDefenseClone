using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Monsters;
using System.Collections;
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

        StartAttackSequence(hero, monster);

    }

    void StartAttackSequence(Hero hero, Monster monster)
    {
        // 코루틴 실행
        StartCoroutine(AttackMonsterRoutine(hero, monster));
    }

    IEnumerator AttackMonsterRoutine(Hero hero,Monster monster)
    {
        // 몬스터가 살아있는 동안 반복
        while (!monster.IsDead)
        {
            // 데미지 주기
            DamageResult result = GameManager.Instance.Damage.DealDamage(hero, monster);

            // 현재 체력 로그 출력
            Debug.Log(monster.Stats.CurrentHP);

            // 1.0초 동안 대기 (원하는 시간으로 변경 가능)
            yield return new WaitForSeconds(1.0f);
        }

        Debug.Log("몬스터를 처치했습니다!");
    }


}
