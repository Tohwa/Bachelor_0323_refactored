using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShopTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    public void ActivateShop() { shop.SetActive(true); }

    public void DeactivateShop() { shop.SetActive(false); }
}
