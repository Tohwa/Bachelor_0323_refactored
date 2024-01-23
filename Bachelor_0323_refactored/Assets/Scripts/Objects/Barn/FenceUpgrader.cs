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
        if(woodCount >= 2 && crystalCount >= 2)
        {
            woodCount -= 2;
            crystalCount -= 2;

            buildFence.Raise();
        }
    }

    public void UpgradeToSolidFence()
    {
        if(woodCount >= 4 && crystalCount >= 4)
        {
            woodCount -= 4;
            crystalCount -= 4;

            upgradeToSolidEvent.Raise();
        }
    }

    public void UpgradeToStrongFence()
    {
        if(woodCount >= 6 && crystalCount >= 6)
        {
            woodCount -= 6;
            crystalCount -= 6;

            upgradeToStrongEvent.Raise();
        }        
    }
}
