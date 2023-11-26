using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FenceBuilder : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;

    public bool canInteract = false;
    public bool buttonPressed = false;

    public void BuildFence()
    {
        if(canInteract && buttonPressed)
        {
            Event.Raise();
        }
    }

    public void Button()
    {
        buttonPressed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
}
