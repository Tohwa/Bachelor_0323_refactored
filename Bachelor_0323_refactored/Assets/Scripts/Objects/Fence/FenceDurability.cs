using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class FenceDurability : MonoBehaviour
{
    public FloatReference durability;

    [HideInInspector] public float hp;

    private void Start()
    {
        hp = durability.Value;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            hp = 0;

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
