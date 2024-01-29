using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class BuildFence : MonoBehaviour
{
    [SerializeField] GameObject fenceParent;
    private UpgradeFence upgrader;

    private void Start()
    {
        upgrader = fenceParent.GetComponent<UpgradeFence>();
    }

    public void Build()
    {
        Debug.Log("Building fence!");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);

        upgrader.weakBuild = true;
    }
}
