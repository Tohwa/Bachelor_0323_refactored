using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarChaseState : BaseState
{
    public BoarChaseState(BoarController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        boar.Agent.SetDestination(boar.target.transform.position);
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        if (!boar.Agent.pathPending)
        {
            if (boar.Agent.remainingDistance <= boar.Agent.stoppingDistance)
            {
                if (!boar.Agent.hasPath || boar.Agent.velocity.sqrMagnitude == 0f)
                {
                    boar.BoarStateMachine.ChangeBoarState(boar.AttackState);
                }
            }
        }
        else if (boar.target.CompareTag("Sheep") && boar.Agent.remainingDistance <= boar.Agent.stoppingDistance * 2)
        {
            boar.timer -= Time.deltaTime;

            if (boar.timer <= 0)
            {
                boar.timer = 0;

                boar.target.GetComponent<SheepHealth>().hp -= boar.damage.Value;

                Debug.Log("Attacking Sheep");

                if (boar.target.GetComponent<SheepHealth>().hp <= 0)
                {
                    boar.target = null;
                    boar.BoarStateMachine.ChangeBoarState(boar.LocateTargetState);
                }
                else
                {
                    boar.timer = boar.attackDelay.Value;
                }

            }
        }
        else if (boar.target == null)
        {
            boar.BoarStateMachine.ChangeBoarState(boar.LocateTargetState);
        }
    }

    public override void PhysicsUpdate()
    {
        boar.Agent.SetDestination(boar.target.transform.position);
    }
}
