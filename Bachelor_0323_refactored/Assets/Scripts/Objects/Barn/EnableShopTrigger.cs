using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShopTrigger : MonoBehaviour
{
    public void ActivateShop() { gameObject.SetActive(true); }

    public void DeactivateShop() { gameObject.SetActive(false); }
}
