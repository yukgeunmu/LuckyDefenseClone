using LuckyDefense.Core.Manager;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.Combat.Update();
    }
}
