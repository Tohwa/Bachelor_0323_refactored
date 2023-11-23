using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSetInteractor : MonoBehaviour
{
    public GameObjectSet sheepList;

    private void OnEnable()
    {
        sheepList.Add(gameObject);
    }

    private void OnDisable()
    {
        sheepList.Remove(gameObject);
    }
}
