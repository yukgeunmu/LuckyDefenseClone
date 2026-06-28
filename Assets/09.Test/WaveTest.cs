
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using UnityEngine;

public class WaveTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventBus.Subscribe<WaveStartedEvent>(OnWaveStarted);

        EventBus.Subscribe<WaveEndedEvent>(OnWaveEnded);

        GameManager.Instance.Wave.StartGame();

    }

    private void OnWaveStarted(IEvent e)
    {
        WaveStartedEvent evt =
            (WaveStartedEvent)e;

        Debug.Log(
            $"Wave Start : "
            + evt.Wave.WaveNumber);

        GameManager.Instance
            .Wave
            .EndWave();
    }

    private void OnWaveEnded(IEvent e)
    {
        WaveEndedEvent evt =
            (WaveEndedEvent)e;

        Debug.Log(
            $"Wave End : "
            + evt.Wave.WaveNumber);
    }


}
