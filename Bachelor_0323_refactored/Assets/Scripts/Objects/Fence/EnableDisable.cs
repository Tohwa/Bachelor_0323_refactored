using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public GameObjectSet fences;

    private void OnEnable()
    {
        fences.Add(gameObject);
    }

    private void OnDisable()
    {
        fences.Remove(gameObject);
    }
}
