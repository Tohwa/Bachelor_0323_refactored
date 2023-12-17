using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class UseShop : MonoBehaviour
{
    public GameEvent startInteractionEvent;
    public GameEvent StopInteractionEvent;

    public UnityEvent startResponse;
    public UnityEvent stopResponse;

    public bool interacting;

    private void Update()
    {
        if (interacting)
        {
            StartToInteract();
        }
        else
        {
            StopToInteract();
        }
    }

    public void InteractWithShop(InputAction.CallbackContext ctx)
    {
        interacting = ctx.performed;
    }

    public void StartToInteract()
    {
        startInteractionEvent.Raise();
    }

    public void StopToInteract()
    {
        StopInteractionEvent.Raise();
    }
}
