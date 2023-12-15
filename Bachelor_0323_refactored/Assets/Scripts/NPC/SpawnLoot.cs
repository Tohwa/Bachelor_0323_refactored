using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    public GameObject crystal;

    private void OnDisable()
    {
        Instantiate(crystal, gameObject.transform.position, crystal.transform.rotation,null);
    }
}
