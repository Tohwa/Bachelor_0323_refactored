using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    public GameObject lootPrefab;

    private void OnDisable()
    {
        Instantiate(lootPrefab, gameObject.transform.position, lootPrefab.transform.rotation,null);
    }
}
