using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WolfAttackState : BaseState
{
    public WolfAttackState(WolfController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {

        if (wolf.target.CompareTag("WeakFencePart") || wolf.target.CompareTag("SolidFencePart") || wolf.target.CompareTag("StrongFencePart"))
        {
            if (wolf.timer <= 0)
            {
                wolf.timer = 0;


                wolf.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp -= wolf.damage.Value;
                Debug.Log("Attacking Fence");

                if (wolf.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp <= 0)
                {
                    wolf.target = null;
                    wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
                }
                else
                {
                    wolf.timer = wolf.attackDelay.Value;
                }
            }
        }
        else if (wolf.target.CompareTag("Sheep") && wolf.Agent.remainingDistance <= wolf.Agent.stoppingDistance * 2)
        {
            if (wolf.timer <= 0)
            {
                wolf.timer = 0;

                wolf.target.GetComponent<SheepHealth>().hp -= wolf.damage.Value;

                Debug.Log("Attacking Sheep");

                if (wolf.target.GetComponent<SheepHealth>().hp <= 0)
                {
                    wolf.target = null;
                    wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
                }
                else
                {
                    wolf.timer = wolf.attackDelay.Value;
                }

            }

            if (wolf.Distance(wolf.transform.position, wolf.target.transform.position) >= wolf.Agent.stoppingDistance)
            {
                wolf.WolfStateMachine.ChangeWolfState(wolf.ChaseState);
            }
        }

    }

    public override void PhysicsUpdate()
    {

    }
}
