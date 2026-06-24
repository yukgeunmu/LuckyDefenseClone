using LuckyDefense.Core.Manager;
using UnityEngine;

public class HeroViewSpawnTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.Resource.AddSilver(100);

        GameManager.Instance.Spawn.SummonHero();
    }

}
