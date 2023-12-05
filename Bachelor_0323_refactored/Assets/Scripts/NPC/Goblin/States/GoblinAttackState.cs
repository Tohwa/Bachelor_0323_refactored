using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : BaseState
{
    public GoblinAttackState(GoblinController _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
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
        goblin.StartCoroutine(goblin.AttackDelay());

        if (goblin.target.CompareTag("Environment"))
        {
            if(goblin.fenceSet.Items.Count == 0)
            {
                goblin.StopCoroutine(goblin.AttackDelay());
                goblin.target = null;
                goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
            }
        }
        else if (goblin.target.CompareTag("Sheep"))
        {
            if(goblin.target.GetComponent<SheepHealth>().health.Value <= 0)
            {
                goblin.StopCoroutine(goblin.AttackDelay());
                goblin.target = null;
                goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
            }
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
