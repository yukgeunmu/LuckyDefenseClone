using UnityEngine;
using LuckyDefense.Monster.Data;
using LuckyDefense.Core.Manager;

public class MonsterDBTest : MonoBehaviour
{
    void Start()
    {
        MonsterData monster = GameManager.Instance.Data.GetMonster(1000);

        Debug.Log(monster.name);
    }


}
