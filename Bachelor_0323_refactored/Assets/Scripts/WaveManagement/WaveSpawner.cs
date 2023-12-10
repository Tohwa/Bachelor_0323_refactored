using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObjectSet spawnSet;
    public GameObjectSet curEnemySet;
    public Wave[] waves;

    private int currentWaveIndex = 0;

    //public void SetSpawnsActive()
    //{
    //    foreach (var obj in spawnSet.Items)
    //    {
    //        obj.gameObject.SetActive(true);
    //    }
    //}

    public void ClearCurWave()
    {
        for(int i = curEnemySet.Items.Count - 1 ; i >= 0 ; i--)
        {
            curEnemySet.Items[i].gameObject.SetActive(false);
        }
    }

    public void SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            int temp;
            int prevTemp = 0;

            temp = Random.Range(0, spawnSet.Items.Count);

            if(temp != prevTemp )
            {
                prevTemp = temp;
            }
            else
            {
                temp = Random.Range(0, spawnSet.Items.Count);
            }

            Instantiate(waves[currentWaveIndex].enemies[i], spawnSet.Items[temp].transform);
        }

        currentWaveIndex++;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] enemies;
}
