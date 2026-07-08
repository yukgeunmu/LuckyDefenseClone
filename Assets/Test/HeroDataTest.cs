using LuckyDefense.Heroes.Data;
using LuckyDefense.Core.Manager;
using UnityEngine;

public class HeroDataTest : MonoBehaviour
{
    private void Start()
    {
        HeroData hero = GameManager.Instance.Data.GetHero(1001);

        Debug.Log(hero.HeroName);
        Debug.Log(hero.AttackPower);
    }
}