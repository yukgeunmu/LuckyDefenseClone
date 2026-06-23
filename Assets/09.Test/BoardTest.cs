using LuckyDefense.Heroes;
using LuckyDefense.Core;
using UnityEngine;

public class BoardTest : MonoBehaviour
{
    private void Start()
    {
        var board =
            GameManager.Instance.Board;

        for (int i = 0; i < 20; i++)
        {
            board.PlaceHero(
                new Hero(i));
        }

        Debug.Log(
            board.GetEmptyCell() == null);
    }
}