using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurSetInteraction : MonoBehaviour
{
    public GameObjectSet curEnemyList;

    private void OnEnable()
    {
        curEnemyList.Add(gameObject);
    }

    private void OnDisable()
    {
        curEnemyList.Remove(gameObject);
    }
}
