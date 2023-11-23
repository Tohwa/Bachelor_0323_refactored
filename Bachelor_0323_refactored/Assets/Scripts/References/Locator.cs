using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator
{
    private Calculations calc;
    public void FindTarget()
    {
        //if (activeTarget == null)
        //{
        //    if (gameObject.CompareTag("Goat"))
        //    {
        //        activeTarget = GameObject.FindGameObjectWithTag("Player");
        //        playerData = activeTarget.GetComponent<Player>();
        //        Debug.Log("Found player as active target.");
        //    }
        //    else if (gameObject.CompareTag("Boar") || gameObject.CompareTag("Wolf"))
        //    {
        //        if (prevTarget == null)
        //        {
        //            FindClosestFence();
        //            Debug.Log("Found closest fence as active target.");
        //        }
        //        else if (prevTarget != null)
        //        {
        //            if (!fence.activeSelf)
        //            {
        //                FindClosestSheep();
        //                Debug.Log("Found closest sheep as active target.");
        //            }
        //        }
        //    }
        //}
    }

    private void LocateSheep()
    {
        float firstDistance;
        float secDistance;

        //if (GameManager.Instance.sheepTargets.Count != 0)
        //{

        //    //firstDistance = calc.Distance(gameObject.transform.position, GameManager.Instance.sheepTargets.First().transform.position);

        //    //activeTarget = GameManager.Instance.sheepTargets.First();

        //    //for (int x = 0; x < GameManager.Instance.sheepTargets.Count; x++)
        //    //{
        //    //    secDistance = calc.Distance(gameObject.transform.position, GameManager.Instance.sheepTargets[x].transform.position);

        //    //    if (firstDistance > secDistance)
        //    //    {
        //    //        activeTarget = GameManager.Instance.sheepTargets[x];
        //    //        firstDistance = secDistance;
        //    //    }
        //    //}

        //    //Agent.stoppingDistance = enemyData.sheepStopDistance;

        //    //sheepData = activeTarget.GetComponent<NeutralNPC>();
        //}
        //else
        //{
        //    Debug.Log("no more sheep available");
        //    return;
        //}
    }

    private void LocateFence()
    {
        float firstDistance;
        float secDistance;

        //if (GameManager.Instance.fenceTargets.Count != 0)
        //{
        //    firstDistance = calc.Distance(gameObject.transform.position, GameManager.Instance.fenceTargets.First().transform.position);

        //    activeTarget = GameManager.Instance.fenceTargets.First();

        //    for (int x = 0; x < GameManager.Instance.fenceTargets.Count; x++)
        //    {
        //        secDistance = calcDistance(gameObject.transform.position, GameManager.Instance.fenceTargets[x].transform.position);

        //        if (firstDistance > secDistance)
        //        {
        //            prevTarget = GameManager.Instance.fenceTargets[x];
        //            activeTarget = GameManager.Instance.fenceTargets[x];
        //            firstDistance = secDistance;
        //        }

        //    }

        //    Agent.stoppingDistance = enemyData.fenceStopDistance;

        //    fence = GameObject.FindGameObjectWithTag("FenceBody");

        //    fenceData = fence.GetComponent<Fence>();

        //    //GameManager.Instance.fenceTargets.Remove(objectTarget);
        //    //GameManager.Instance.sheepTargets.Clear();
        //}
        //else
        //{
        //    Debug.Log("no more fences available");
        //    return;
        //}
    }
}
