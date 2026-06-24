using LuckyDefense.Core.Manager;
using UnityEngine;

public class SummonTest : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Resource
            .AddSilver(100);

        for (int i = 0; i < 5; i++)
        {
            GameManager.Instance.Spawn
                .SummonHero();
        }
    }
}