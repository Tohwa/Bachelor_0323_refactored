using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSetInteract : MonoBehaviour
{
    public GameObjectSet wolfList;

    private void OnEnable()
    {
        wolfList.Add(gameObject);
    }

    private void OnDisable()
    {
        wolfList.Remove(gameObject);
    }
}
