using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Manager;
using LuckyDefense.UI.Scene;
using System.Threading.Tasks;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    private void Start()
    {
        Init().Forget();

        GameManager.Instance.StartGame();
    }


    private async UniTask Init()
    {
        await GameManager.Instance.UI.ShowScene<SpawnUI>();
    }

}
