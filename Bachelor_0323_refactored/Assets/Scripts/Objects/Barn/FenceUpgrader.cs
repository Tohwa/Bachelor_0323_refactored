using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class FenceUpgrader : MonoBehaviour
{
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
}
