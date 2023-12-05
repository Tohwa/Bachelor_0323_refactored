using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    public FloatReference roundTimer;

    public bool preparation;
    public bool combat;

    private float timer;


    void Start()
    {
        preparation = true;
        combat = false;

        timer = roundTimer.Value;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && preparation)
        {
            preparation = false;
            combat = true;
            timer = roundTimer.Value;
            gameEvent.Raise();
        }
        else if(timer <= 0 && combat)
        {
            preparation = true;
            combat = false;
            timer = roundTimer.Value;
        }
    }
}
