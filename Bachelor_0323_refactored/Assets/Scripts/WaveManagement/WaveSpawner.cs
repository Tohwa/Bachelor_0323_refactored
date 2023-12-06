using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObjectSet enemySpawnPosition;
    public Wave[] waves;

    private int currentWaveIndex = 0;

    public void SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            Instantiate(waves[currentWaveIndex].enemies[i], enemySpawnPosition.Items[i].transform);
        }

        currentWaveIndex++;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] enemies;
}
