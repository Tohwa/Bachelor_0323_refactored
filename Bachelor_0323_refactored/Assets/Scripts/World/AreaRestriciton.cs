using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRestriciton : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
