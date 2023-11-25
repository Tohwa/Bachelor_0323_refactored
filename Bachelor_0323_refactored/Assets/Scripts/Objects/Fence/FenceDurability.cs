using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceDurability : MonoBehaviour
{
    public FloatReference durability;
    private void Update()
    {
        if (durability.Value <= 0)
        {
            gameObject.SetActive(false);
            //remove from active enemy List -- look up Video on discord talk03/23
        }
    }
}
