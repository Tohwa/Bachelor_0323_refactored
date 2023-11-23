using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{
    public FloatVariable speed;

    public Locator locator;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine WolfStateMachine { get; private set; }

    public WolfLocateState LocateTargetState { get; private set; }
    public WolfAttackState AttackState { get; private set; }
    public WolfChaseState ChaseState { get; private set; }

    private void Awake()
    {
        WolfStateMachine = new StateMachine();

        LocateTargetState = new WolfLocateState(this, WolfStateMachine);
        ChaseState = new WolfChaseState(this, WolfStateMachine);
        AttackState = new WolfAttackState(this, WolfStateMachine);
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        Agent.speed = speed.Value;

        WolfStateMachine.InitWolfState(LocateTargetState);
    }

    private void Update()
    {
        WolfStateMachine.wolfState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        WolfStateMachine.wolfState.PhysicsUpdate();
    }   
}
