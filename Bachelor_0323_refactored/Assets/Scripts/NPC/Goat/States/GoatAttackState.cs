using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatAttackState : BaseState
{
    public GoatAttackState(GoatController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        if (goat.timer <= 0)
        {
            goat.timer = 0;

            goat.target.GetComponent<PlayerHealth>().hp -= goat.damage.Value;

            Debug.Log("Attacking Player");

            if (goat.target.GetComponent<PlayerHealth>().hp <= 0)
            {
                goat.target = null;
            }
            else
            {
                goat.timer = goat.attackDelay.Value;
            }
        }

        if (goat.Distance(goat.transform.position, goat.target.transform.position) >= goat.Agent.stoppingDistance)
        {
            goat.GoatStateMachine.ChangeGoatState(goat.ChaseState);
        }

    }

    public override void PhysicsUpdate()
    {

    }
}
