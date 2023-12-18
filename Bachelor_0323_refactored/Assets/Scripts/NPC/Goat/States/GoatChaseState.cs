using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatChaseState : BaseState
{
    public GoatChaseState(GoatController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void EnterState()
    {
        goat.Agent.SetDestination(goat.target.transform.position);
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        if (goat.Agent.remainingDistance <= goat.Agent.stoppingDistance * 2)
        {
            goat.timer -= Time.deltaTime;

            if (goat.timer <= 0)
            {
                goat.timer = 0;

                goat.target.GetComponent<SheepHealth>().hp -= goat.damage.Value;

                Debug.Log("Attacking Sheep");

                if (goat.target.GetComponent<SheepHealth>().hp <= 0)
                {
                    goat.target = null;
                    goat.GoatStateMachine.ChangeGoatState(goat.LocateTargetState);
                }
                else
                {
                    goat.timer = goat.attackDelay.Value;
                }

            }
        }
        else if (goat.target == null)
        {
            goat.GoatStateMachine.ChangeGoatState(goat.LocateTargetState);
        }
    }

    public override void PhysicsUpdate()
    {
        goat.Agent.SetDestination(goat.target.transform.position);
    }
}
