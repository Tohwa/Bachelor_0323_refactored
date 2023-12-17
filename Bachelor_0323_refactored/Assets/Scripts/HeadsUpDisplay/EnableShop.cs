using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShop : MonoBehaviour
{
    public void ActivateShop() { gameObject.transform.GetChild(0).gameObject.SetActive(true); }
}
