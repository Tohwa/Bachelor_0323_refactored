using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor.AI;
using UnityEngine;

public class FenceDurability : MonoBehaviour
{
    public FloatReference durability;

    private void Update()
    {
        if (durability.Value <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
