using LuckyDefense.Core.Manager;
using UnityEngine;

public class HeroViewMultiSpawnTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.Resource.AddSilver(1000);

        for (int i = 0; i < 5; i++)
        {
            GameManager.Instance.Spawn.SummonHero();
        }
    }
}
