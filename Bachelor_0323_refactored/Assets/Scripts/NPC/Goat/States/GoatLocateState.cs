using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatLocateState : BaseState
{
    public GoatLocateState(GoatController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        if(goat.target != null)
        {
            goat.GoatStateMachine.ChangeGoatState(goat.ChaseState);
        }
    }

    public override void PhysicsUpdate()
    {

    }

    private void FindTarget()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        goat.target = temp;
    }
}
