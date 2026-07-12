using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

public class CombatTest : MonoBehaviour
{

    void Start()
    {

        GameManager.Instance.Init();

        GameManager.Instance.Goods.AddGold(1000);

        for (int i = 0; i < 1; i++)
        {
            GameManager.Instance.Spawn.SummonHero();
        }

        GameManager.Instance.Wave.StartGame();
    }

    //void Update()
    //{
    //    GameManager.Instance.Combat.Update();
    //}
}
