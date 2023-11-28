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

    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        sheep.timer += Time.deltaTime;

        if (sheep.timer >= sheep.wanderTimer.Value)
        {
            Vector3 newPos = RandomNavSphere(sheep.transform.position, sheep.wanderRadius.Value, 3);
            sheep.Agent.SetDestination(newPos);
            sheep.timer = 0;
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
}
