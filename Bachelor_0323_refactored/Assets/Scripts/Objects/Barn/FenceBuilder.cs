using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FenceBuilder : MonoBehaviour
{
    public GameEvent initFence;
    public UnityEvent Response;

    public bool canInteract = false;
    public bool buttonPressed = false;

    public void Build()
    {
        if(canInteract)
        {
            initFence.Raise();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
}
