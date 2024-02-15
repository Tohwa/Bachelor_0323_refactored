using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObjectSet curEnemySet;

    public GameEvent prepEvent;
    public UnityEvent prepResponse;

    public GameEvent combatEvent;
    public UnityEvent combatResponse;

    public FloatReference prepTimer;
    public FloatReference combatTimer;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObjectSet sheepSet;

    public bool preparation;
    public bool combat;
    public bool gamePaused;


    public float timer;

    [Header("Menu Values")]
    public static float masterSliderValue = 0.75f;
    public static float SFXSliderValue = 0.75f;
    public static float BGMSliderValue = 0.75f;

    public static int resolutionWidth = 1920;
    public static int resolutionHeight = 1080;

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

        if(playerHealth.hp == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else if(sheepSet.Items.Count == 0)
        {
            SceneManager.LoadScene("EndScreen");
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
