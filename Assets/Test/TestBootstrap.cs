using LuckyDefense.Core.Manager;
using UnityEngine;

public class TestBootstrap : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Goods.AddGold(100);
    }
}