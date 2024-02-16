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
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {       
        //if (sheep.timer >= sheep.wanderTimer.Value)
        //{
        //    Vector3 newPos = RandomNavSphere(sheep.transform.position, sheep.wanderRadius.Value, 3);
        //    sheep.Agent.SetDestination(newPos);
        //    sheep.timer = 0;  
        //}

        if(sheep.prevHP > sheep.hp)
        {
            Vector3 newPos = RandomNavSphere(sheep.transform.position, sheep.wanderRadius.Value, 3);
            sheep.travelDistance = Distance(sheep.transform.position, newPos);

            if(sheep.travelDistance > 8)
            {
                sheep.Agent.speed = 10;
                sheep.Agent.SetDestination(newPos);

                sheep.prevHP = sheep.hp;
            }
        }

        if (sheep.journeyHome)
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
