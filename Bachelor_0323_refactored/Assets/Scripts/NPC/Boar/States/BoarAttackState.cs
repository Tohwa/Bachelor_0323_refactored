using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarAttackState : BaseState
{
    public BoarAttackState(BoarController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        if (boar.target.CompareTag("WeakFencePart") || boar.target.CompareTag("SolidFencePart") || boar.target.CompareTag("StrongFencePart"))
        {
            if (boar.timer <= 0)
            {
                boar.timer = 0;

                boar.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp -= boar.damage.Value;
                Debug.Log("Attacking Fence");

                if (boar.target.transform.parent.transform.parent.GetComponent<FenceDurability>().hp <= 0)
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
        else if (boar.target.CompareTag("Sheep") && boar.Agent.remainingDistance <= boar.Agent.stoppingDistance)
        {
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
                    boar.timer -= Time.deltaTime;
                }
            }

            if (boar.Distance(boar.transform.position, boar.target.transform.position) >= boar.Agent.stoppingDistance)
            {
                boar.BoarStateMachine.ChangeBoarState(boar.ChaseState);
            }
        }

        boar.timer -= Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        
    }
}
