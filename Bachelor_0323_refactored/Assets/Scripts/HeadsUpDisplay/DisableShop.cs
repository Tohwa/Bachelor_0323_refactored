using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShop : MonoBehaviour
{
    public void DeactivateShop() { gameObject.transform.GetChild(0).gameObject.SetActive(false); }
}
