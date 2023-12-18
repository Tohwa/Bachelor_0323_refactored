using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfChaseState : BaseState
{
    public WolfChaseState(WolfController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        wolf.Agent.SetDestination(wolf.target.transform.position);
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if (!wolf.Agent.pathPending && wolf.target.CompareTag("Environment"))
        {
            if (wolf.Agent.remainingDistance <= wolf.Agent.stoppingDistance)
            {
                if (!wolf.Agent.hasPath || wolf.Agent.velocity.sqrMagnitude == 0f)
                {
                    wolf.WolfStateMachine.ChangeWolfState(wolf.AttackState);
                }
            }
        }
        else if (wolf.target.CompareTag("Sheep") && wolf.Agent.remainingDistance <= wolf.Agent.stoppingDistance * 2)
        {
            wolf.timer -= Time.deltaTime;

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
        }
        else if (wolf.target == null)
        {
            wolf.WolfStateMachine.ChangeWolfState(wolf.LocateTargetState);
        }
    }

    public override void PhysicsUpdate()
    {
        wolf.Agent.SetDestination(wolf.target.transform.position);
    }
}
