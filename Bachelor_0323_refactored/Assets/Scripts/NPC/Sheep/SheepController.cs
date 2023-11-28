using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepController : MonoBehaviour
{

    public FloatReference speed;
    public FloatReference wanderRadius;
    public FloatReference wanderTimer;
    public float timer;

    public NavMeshAgent Agent { get; private set; }

    public StateMachine SheepStateMachine { get; private set; }

    public CozyState CozyState { get; private set; }
    public AlarmedState AlarmedState { get; private set; }
    public EscapeState EscapeState { get; private set; }
    public ReturnHomeState ReturnState { get; private set; }

    public GameObjectSet fenceSet;

    private void Awake()
    {
        SheepStateMachine = new StateMachine();
    }

    private void Start()
    {
        if (Agent == null)
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        Agent.speed = speed.Value;

        if(fenceSet.Items.Count > 0 )
        {
            SheepStateMachine.InitSheepState(CozyState);
        }
        else
        {
            //SheepStateMachine.InitSheepState(AlarmedState);
        }

    }

    private void Update()
    {
        SheepStateMachine.goblinState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        SheepStateMachine.goblinState.PhysicsUpdate();
    }
}
