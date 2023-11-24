using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WolfLocateState : BaseState
{
    public WolfLocateState(WolfController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        FindTarget();
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if(wolf.target != null)
        {
            wolf.WolfStateMachine.ChangeWolfState(wolf.ChaseState);
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public void FindTarget()
    {
        if (wolf.target == null)
        {
            if (wolf.fenceSet.Items.Count != 0)
            {
                FindClosestFence();
                Debug.Log("Found closest fence as active target.");
            }
            else
            {
                //FindClosestSheep();
                Debug.Log("Found closest sheep as active target.");
            }

        }
    }

    private void FindClosestFence()
    {
        List<float> tempL = new List<float>();
        List<GameObject> tempR = new List<GameObject>();

        foreach (GameObject item in wolf.fenceSet.Items)
        {
            float calcfloat = Distance(wolf.transform.position, item.transform.position);
            tempL.Add(calcfloat);
            tempR.Add(item);
        }

        int n = tempR.Count;

        
            for (int j = 0; j == n - 1; j++)
            {
                if (tempL[j] < tempL[j + 1])
                {
                    float tempF = tempL[j];
                    GameObject tempG = tempR[j];
                    tempL[j] = tempL[j + 1];
                    tempR[j] = tempR[j + 1];
                    tempL[j + 1] = tempF;
                    tempR[j + 1] = tempG;
                }
            }
        

        wolf.target = wolf.fenceSet.Items[0];
    }

    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
