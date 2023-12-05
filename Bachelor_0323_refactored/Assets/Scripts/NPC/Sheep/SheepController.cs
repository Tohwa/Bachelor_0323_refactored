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

    public bool escape;

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

        CozyState = new CozyState(this, SheepStateMachine);
        AlarmedState = new AlarmedState(this, SheepStateMachine);
        EscapeState = new EscapeState(this, SheepStateMachine);
        ReturnState = new ReturnHomeState(this, SheepStateMachine);
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
            SheepStateMachine.InitSheepState(AlarmedState);
        }

    }

    private void Update()
    {
        SheepStateMachine.sheepState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        SheepStateMachine.sheepState.PhysicsUpdate();
    }

    public void RunAway()
    {
        escape = true;
    }
}
