using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class UpgradeFence : MonoBehaviour
{
    public bool weakBuild = false;
    public bool solidBuild = false;
    public bool strongBuild = false;

    private FenceUpgrader upgrader;

    private void Start()
    {
        upgrader = GetComponent<FenceUpgrader>();
    }

    private List<GameObject> GetAllChildren(Transform Parent)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in Parent)
        {
            children.Add(child.gameObject);
            children.AddRange(GetAllChildren(child));
        }
        return children;
    }

    public void DisableWeakFence()
    {
        if (weakBuild)
        {
            List<GameObject> allChildren = GetAllChildren(transform);
            foreach (var child in allChildren)
            {
                if (child.CompareTag("WeakFencePart"))
                {
                    child.SetActive(false);
                }
            }
        }
    }

    public void DisableSolidFence()
    {
        if (solidBuild)
        {
            List<GameObject> allChildren = GetAllChildren(transform);
            foreach (var child in allChildren)
            {
                if (child.CompareTag("SolidFencePart"))
                {
                    child.SetActive(false);
                }
            }
        }
    }

    public void ActivateSolidFence()
    {
        if (weakBuild && !solidBuild)
        {
            List<GameObject> allChildren = GetAllChildren(transform);
            foreach (var child in allChildren)
            {
                if(child.CompareTag("SolidFencePart"))
                {
                    child.SetActive(true);
                }
            }

            solidBuild = true;
        }
    }

    public void ActivateStrongFence()
    {
        if (solidBuild && weakBuild && !strongBuild)
        {
            List<GameObject> allChildren = GetAllChildren(transform);
            foreach (var child in allChildren)
            {
                if (child.CompareTag("StrongFencePart"))
                {
                    child.SetActive(true);
                }
            }

            strongBuild = true;
        }
    }

    public void ResetFenceState()
    {
        weakBuild = false;
        solidBuild = false;
        strongBuild = false;
    }
}
