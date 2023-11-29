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
        goblin.StartCoroutine(goblin.AttackDelay());
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        float temp;

        temp = Distance(goblin.transform.position, goblin.target.transform.position);

        if (goblin.target.CompareTag("Environment"))
        {
            if (temp <= goblin.Agent.stoppingDistance)
            {
                goblin.StopCoroutine(goblin.AttackDelay());
                goblin.GoblinStateMachine.ChangeGoblinState(goblin.ChaseState);
            }
            else if(goblin.target.GetComponent<FenceDurability>().durability.Value <= 0)
            {
                goblin.StopCoroutine(goblin.AttackDelay());
                goblin.target = null;
                goblin.GoblinStateMachine.ChangeGoblinState(goblin.LocateTargetState);
            }
        }
        else if (goblin.target.CompareTag("Sheep"))
        {
            if (temp <= goblin.Agent.stoppingDistance)
            {
                goblin.StopCoroutine(goblin.AttackDelay());
                goblin.GoblinStateMachine.ChangeGoblinState(goblin.ChaseState);
            }
            else if(goblin.target.GetComponent<SheepHealth>().health.Value <= 0)
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
