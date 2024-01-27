using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLocateState : BaseState
{
    public BossLocateState(BossController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        if (boss.target != null)
        {
            boss.BossStateMachine.ChangeBossState(boss.ChaseState);
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public void FindTarget()
    {
        if (boss.target == null)
        {
            if (boss.fenceSet.Items.Count != 0)
            {
                FindClosestFence();
            }
            else if (boss.fenceSet.Items.Count == 0)
            {
                FindClosestSheep();
            }

        }
    }

    private void FindClosestFence()
    {
        List<float> tempL = new List<float>();
        List<GameObject> tempR = new List<GameObject>();

        foreach (GameObject item in boss.fenceSet.Items)
        {
            float calcfloat = Distance(boss.transform.position, item.transform.position);
            tempL.Add(calcfloat);
            tempR.Add(item);
        }

        int n = tempR.Count;


        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (tempL[j] > tempL[j + 1])
                {
                    float tempF = tempL[j];
                    GameObject tempG = tempR[j];
                    tempL[j] = tempL[j + 1];
                    tempR[j] = tempR[j + 1];
                    tempL[j + 1] = tempF;
                    tempR[j + 1] = tempG;
                }
            }
        }

        boss.target = tempR[0];
    }

    private void FindClosestSheep()
    {
        if (boss.sheepSet.Items.Count > 0)
        {
            List<float> tempL = new List<float>();
            List<GameObject> tempR = new List<GameObject>();

            foreach (GameObject item in boss.sheepSet.Items)
            {
                float calcfloat = Distance(boss.transform.position, item.transform.position);
                tempL.Add(calcfloat);
                tempR.Add(item);
            }

            int n = tempR.Count;


            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (tempL[j] > tempL[j + 1])
                    {
                        float tempF = tempL[j];
                        GameObject tempG = tempR[j];
                        tempL[j] = tempL[j + 1];
                        tempR[j] = tempR[j + 1];
                        tempL[j + 1] = tempF;
                        tempR[j + 1] = tempG;
                    }
                }
            }

            boss.target = tempR[0];
        }
    }

    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
