using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CozyState : BaseState
{
    public CozyState(SheepController _ally, StateMachine _stateMachine) : base(_ally, _stateMachine)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Cozy!");

        sheep.Agent.speed = 3f;
        sheep.Agent.acceleration = 8;
    }

    public override void ExitState()
    {
        
    }

    public override void LogicUpdate()
    {
        if (sheep.timer >= sheep.wanderTimer.Value)
        {
            Vector3 newPos = RandomNavSphere(sheep.cage.transform.position, sheep.wanderRadius.Value, 3);
            sheep.Agent.SetDestination(newPos);
            sheep.timer = 0;
        }

        sheep.timer += Time.deltaTime;

        if (sheep.fenceSet.Items.Count == 0)
        {
            sheep.SheepStateMachine.ChangeSheepState(sheep.AlarmedState);
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
