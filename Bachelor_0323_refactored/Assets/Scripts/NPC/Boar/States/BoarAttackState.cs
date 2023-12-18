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
        boar.timer -= Time.deltaTime;

        if (boar.timer <= 0)
        {
            boar.timer = 0;

            if (boar.target.CompareTag("Environment"))
            {
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
    }

    public override void PhysicsUpdate()
    {
        
    }
}
