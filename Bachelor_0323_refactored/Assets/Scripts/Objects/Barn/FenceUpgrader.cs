using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class FenceUpgrader : MonoBehaviour
{
    public GameEvent upgradeToSolidEvent;
    public GameEvent upgradeToStrongEvent;
    public GameEvent buildFence;
    public UnityEvent buildResponse;
    public UnityEvent solidResponse;
    public UnityEvent strongResponse;

    public int crystalCount;
    public int woodCount;

    [SerializeField] private bool weakFenceBuilt = false;
    [SerializeField] private bool solidFenceBuilt = false;
    [SerializeField] private bool strongFenceBuilt = false;

    public void IncreaseCrystalCount()
    {
        crystalCount += 1;
    }

    public void IncreaseWoodCount()
    {
        woodCount += 1;
    }

    public void BuildFence()
    {
        if (!weakFenceBuilt && !solidFenceBuilt && !strongFenceBuilt && woodCount >= 2 && crystalCount >= 2)
        {
            weakFenceBuilt = true;
            woodCount -= 2;
            crystalCount -= 2;

            buildFence.Raise();
        }

    }

    public void UpgradeToSolidFence()
    {
        if (weakFenceBuilt && !solidFenceBuilt && woodCount >= 4 && crystalCount >= 4)
        {
            woodCount -= 4;
            crystalCount -= 4;

            upgradeToSolidEvent.Raise();
            solidFenceBuilt = true;
        }

    }

    public void UpgradeToStrongFence()
    {

        if (solidFenceBuilt && !strongFenceBuilt && woodCount >= 6 && crystalCount >= 6)
        {
            woodCount -= 6;
            crystalCount -= 6;

            upgradeToStrongEvent.Raise();
            strongFenceBuilt = true;
        }

    }

    public void ResetFenceState()
    {
        weakFenceBuilt = false;
        solidFenceBuilt = false;
        strongFenceBuilt = false;
    }
}

