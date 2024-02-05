using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoarController : MonoBehaviour
{
    public GameObject target;

    public FloatReference speed;
    public FloatReference damage;
    public FloatReference attackDelay;

    public float timer;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine BoarStateMachine { get; private set; }

    public BoarLocateState LocateTargetState { get; private set; }
    public BoarAttackState AttackState { get; private set; }
    public BoarChaseState ChaseState { get; private set; }

    public GameObjectSet sheepSet;
    public GameObjectSet fenceSet;

    private void Awake()
    {
        BoarStateMachine = new StateMachine();

        LocateTargetState = new BoarLocateState(this, BoarStateMachine);
        ChaseState = new BoarChaseState(this, BoarStateMachine);
        AttackState = new BoarAttackState(this, BoarStateMachine);
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }
        
        Agent.speed = speed.Value;

        BoarStateMachine.InitBoarState(LocateTargetState);
    }

    private void Update()
    {
        BoarStateMachine.boarState.LogicUpdate();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        BoarStateMachine.boarState.PhysicsUpdate();
    }

    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
