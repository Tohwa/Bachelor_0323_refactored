using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObjectSet spawnSet;
    public GameObjectSet curEnemySet;
    public Wave[] waves;

    private int currentWaveIndex = 0;

    public void ClearCurWave()
    {
        for (int i = curEnemySet.Items.Count - 1; i >= 0; i--)
        {
            curEnemySet.Items[i].gameObject.SetActive(false);
        }
    }

    public void SpawnWave()
    {
        int temp;
        List<int> tempList = new List<int>();

        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            tempList.Add(0);

            temp = Random.Range(0, spawnSet.Items.Count);

            while(tempList.Count < waves[currentWaveIndex].enemies.Length)
            {
                if (!tempList.Contains(temp))
                {
                    tempList.Add(temp);
                }
                else
                {
                    temp = Random.Range(0, spawnSet.Items.Count);
                }
            } 
        }


        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            Instantiate(waves[currentWaveIndex].enemies[i], spawnSet.Items[tempList[i]].transform);
        }

        currentWaveIndex++;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] enemies;
}
