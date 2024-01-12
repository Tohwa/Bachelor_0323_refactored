using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObjectSet curEnemySet;

    public GameEvent prepEvent;
    public UnityEvent prepResponse;

    public GameEvent combatEvent;
    public UnityEvent combatResponse;

    public FloatReference prepTimer;
    public FloatReference combatTimer;

    public bool preparation;
    public bool combat;
    public bool gamePaused;

    public float timer;

    [Header("Menu Values")]
    public static float masterSliderValue = 0.75f;
    public static float SFXSliderValue = 0.75f;
    public static float BGMSliderValue = 0.75f;

    public static int resolutionWidth;
    public static int resolutionHeight;


    void Start()
    {
        preparation = true;
        combat = false;

        timer = prepTimer.Value;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && preparation)
        {
            preparation = false;
            combat = true;
            timer = combatTimer.Value;
            SendCombatMessage();
        }
        else if (timer <= 0 && combat || combat && curEnemySet.Items.Count == 0)
        {
            preparation = true;
            combat = false;
            timer = prepTimer.Value;
            SendPrepMessage();
        }
    }

    public void SendPrepMessage()
    {
        prepEvent.Raise();
    }

    public void SendCombatMessage()
    {
        combatEvent.Raise();
    }
}
