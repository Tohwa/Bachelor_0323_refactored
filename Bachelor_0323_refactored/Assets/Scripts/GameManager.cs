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

    [Header("RundenCounter")]
    [SerializeField] private int roundCounter;
    [SerializeField] private GameObject BossHUD;


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
            roundCounter++;
            timer = combatTimer.Value;
            SendCombatMessage();
        }
        else if (timer <= 0 && combat && roundCounter != 10|| combat && curEnemySet.Items.Count == 0 && roundCounter != 10)
        {
            preparation = true;
            combat = false;
            timer = prepTimer.Value;
            SendPrepMessage();
        }

        if(Time.timeScale == 0)
        {
            gamePaused = true;
        }
        else
        {
            gamePaused = false;
        }

        if(roundCounter == 10)
        {
            BossHUD.SetActive(true);
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
