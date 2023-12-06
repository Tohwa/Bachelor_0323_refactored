using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObjectSet enemySpawnPosition;

    private void OnEnable()
    {
        enemySpawnPosition.Add(gameObject);
    }

    private void OnDisable()
    {
        enemySpawnPosition.Remove(gameObject);
    }
}
