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

        GameManager.Instance.HeroState.Update();

        GameManager.Instance.Projectile.Update();

        GameManager.Instance.Orbit.Update();

        GameManager.Instance.Spawn.RemoveDeadMonsters();

    }
}
