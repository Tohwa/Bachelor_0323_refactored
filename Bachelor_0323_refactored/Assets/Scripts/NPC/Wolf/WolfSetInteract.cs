using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WolfSetInteract : MonoBehaviour
{
    public GameEvent AddToList;
    public GameEvent RemoveFromList;
    public UnityEvent addition;
    public UnityEvent substraction;

    private void OnEnable()
    {
        AddToList.Raise();
    }

    private void OnDisable()
    {
        RemoveFromList.Raise();
    }
}
