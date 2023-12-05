using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEditor : MonoBehaviour
{
    public GameObjectSet wolfSet;

    public void AddToList()
    {
        wolfSet.Add(gameObject);
    }

    public void RemoveFromList()
    {
        wolfSet.Remove(gameObject);
    }
}
