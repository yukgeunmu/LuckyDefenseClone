using LuckyDefense.Core.Manager;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        GameManager.Instance.Wave.Update();

        GameManager.Instance.Spawn.Update();

        GameManager.Instance.Skill.Update();

        GameManager.Instance.Combat.Update();

        GameManager.Instance.Projectile.Update();

    }
}
