using LuckyDefense.Core.Manager;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.StartGame();
    }

}
