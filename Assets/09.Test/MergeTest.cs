using LuckyDefense.Core.Manager;
using UnityEngine;

public class MergeTest : MonoBehaviour
{
    private void Start()
    {
        var spawn =
            GameManager.Instance.Spawn;

        GameManager.Instance.Resource
            .AddGold(100);

        spawn.SummonHero();
        spawn.SummonHero();
        spawn.SummonHero();

        //bool success =
        //    GameManager.Instance.Merge
        //        .TryMerge(1001);

        //Debug.Log(success);
    }
}