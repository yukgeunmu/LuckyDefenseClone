using LuckyDefense.Core.Manager;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.Combat.Update();

        GameManager.Instance.Projectile.Update();

        GameManager.Instance.Skill.Update();
    }
}
