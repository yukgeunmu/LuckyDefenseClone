using LuckyDefense.Core;
using UnityEngine;

public class TestBootstrap : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Resource.AddSilver(100);
    }
}