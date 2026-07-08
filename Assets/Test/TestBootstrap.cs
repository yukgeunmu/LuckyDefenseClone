using LuckyDefense.Core.Manager;
using UnityEngine;

public class TestBootstrap : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Resource.AddGold(100);
    }
}