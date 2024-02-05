using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinController : MonoBehaviour
{
    public GameObject target;

    public FloatReference speed;
    public FloatReference damage;
    public FloatReference attackDelay;

    public float timer = 0f;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine GoblinStateMachine { get; private set; }

    public GoblinLocateState LocateTargetState { get; private set; }
    public GoblinAttackState AttackState { get; private set; }
    public GoblinChaseState ChaseState { get; private set; }

    public GameObjectSet sheepSet;
    public GameObjectSet fenceSet;

    private void Awake()
    {
        GoblinStateMachine = new StateMachine();

        LocateTargetState = new GoblinLocateState(this, GoblinStateMachine);
        ChaseState = new GoblinChaseState(this, GoblinStateMachine);
        AttackState = new GoblinAttackState(this, GoblinStateMachine);
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        Agent.speed = speed.Value;
        GoblinStateMachine.InitGoblinState(LocateTargetState);
    }

    private void Update()
    {
        GoblinStateMachine.goblinState.LogicUpdate();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        GoblinStateMachine.goblinState.PhysicsUpdate();
    }

    public float Distance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }
}
