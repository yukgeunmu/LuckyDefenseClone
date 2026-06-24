using LuckyDefense.Core.Manager;
using UnityEngine;

public class BoardFullTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.Resource.AddSilver(10000);

        for (int i = 0; i < 25; i++)
        {
            bool result =
                GameManager.Instance.Spawn
                    .SummonHero();

            Debug.Log(
                $"Summon {i} : {result}");
        }
    }

}
