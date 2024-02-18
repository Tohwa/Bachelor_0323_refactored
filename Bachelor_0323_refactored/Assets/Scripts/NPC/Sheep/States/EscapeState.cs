using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EscapeState : BaseState
{

    public EscapeState(SheepController _ally, StateMachine _stateMachine) : base(_ally, _stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("running");

        Vector3 newPos = RandomNavSphere(sheep.cage.transform.position, sheep.wanderRadius.Value * 3, 3);
        sheep.travelDistance = Distance(sheep.transform.position, newPos);
        sheep.traveledPos = newPos;

        if (sheep.travelDistance > 15)
        {
            sheep.Agent.SetDestination(newPos);

            if (sheep.transform.position == newPos)
            {
                sheep.escape = false;
            }
        }
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {

        if (!sheep.Agent.pathPending)
        {
            if (sheep.Agent.remainingDistance <= sheep.Agent.stoppingDistance)
            {
                if (!sheep.Agent.hasPath || sheep.Agent.velocity.sqrMagnitude == 0f)
                {
                    sheep.escape = false;
                    sheep.SheepStateMachine.ChangeSheepState(sheep.AlarmedState);
                    sheep.Agent.ResetPath();
                }
            }
        }
        else if (sheep.journeyHome)
        {
            sheep.SheepStateMachine.ChangeSheepState(sheep.ReturnState);
        }
    }

    public override void PhysicsUpdate()
    {

    }

    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
