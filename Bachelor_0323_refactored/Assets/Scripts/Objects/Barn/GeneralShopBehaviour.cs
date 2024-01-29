using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralShopBehaviour : MonoBehaviour
{
    public GameEvent openShopEvent;
    public UnityEvent openResponse;

    public GameEvent closeShopeEvent;
    public UnityEvent closeResponse;

    public bool canInteract = false;
    public bool isInUse = false;

    private void Update()
    {
        if(canInteract && isInUse)
        {
            OpenShopHUD();
        }
        else if(!canInteract)
        {
            CloseShopeHUD();
        }
    }

    public void OpenShopHUD()
    {
        openShopEvent.Raise();
    }

    public void CloseShopeHUD()
    {
        closeShopeEvent.Raise();
    }

    public void ShopIsCalled()
    {
        isInUse = true;
    }

    public void ShopIsNoLongerCalled()
    {
        isInUse = false;
    }

    private void OnDisable()
    {
        canInteract = false;
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
