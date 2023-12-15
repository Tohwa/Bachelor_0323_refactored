using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableCrystal : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameEvent.Raise();
            gameObject.SetActive(false);
        }
    }
}
