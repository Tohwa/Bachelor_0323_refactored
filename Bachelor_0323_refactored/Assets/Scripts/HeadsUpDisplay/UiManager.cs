using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject graphicsMenu;
    [SerializeField] private GameObject keyMapMenu;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TextMeshProUGUI masterText;
    [SerializeField] private TextMeshProUGUI bgmText;
    [SerializeField] private TextMeshProUGUI sfxText;
    [SerializeField] private Toggle windowedToggle;
    [SerializeField] private Toggle fullscreenToggle;

    [Header("Components")]
    [SerializeField] private AudioMixer mixer;

    [Header("Scripts")]
    [SerializeField] private GameManager manager;
    #endregion

    private void Awake()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    private void Start()
    {
        MasterTextValue(masterSlider.value);
        masterSlider.onValueChanged.AddListener(MasterTextValue);
        BGMTextValue(bgmSlider.value);
        bgmSlider.onValueChanged.AddListener(BGMTextValue);
        SFXTextValue(sfxSlider.value);
        sfxSlider.onValueChanged.AddListener(SFXTextValue);

        fullscreenToggle.isOn = Screen.fullScreen;
        windowedToggle.isOn = !Screen.fullScreen;
        windowedToggle.onValueChanged.AddListener(OnWindowToggleChange);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggleChange);
    }

    private void Update()
    {        
        if(manager.gamePaused)
        {
            PauseGame();
        }
    }

    public void OnFullscreenToggleChange(bool _value)
    {
        if (_value)
        {
            windowedToggle.isOn = !_value;
            Screen.fullScreen = true;
        }
    }

    public void OnWindowToggleChange(bool _value)
    {
        if (_value)
        {
            fullscreenToggle.isOn = !_value;
            Screen.fullScreen = false;
        }
    }

    public void PauseGame()
    {
        if (!manager.gamePaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        manager.gamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }    

    public void MainMenu()
    {
        Time.timeScale = 1f;
        manager.gamePaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsMenu()
    {
        if (manager.gamePaused)
        {
            pauseMenu.SetActive(false);
            audioMenu.SetActive(false);
            keyMapMenu.SetActive(false);
            graphicsMenu.SetActive(true);
            settingsMenu.SetActive(true);
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        manager.gamePaused = false;
        SceneManager.LoadScene("Sascha");
        
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    public void SetVolumeMaster(float _volume)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(_volume) * 20);
    }

    public void SetVolumeBGM(float _volume)
    {
        mixer.SetFloat("BGMVol", Mathf.Log10(_volume) * 20);
    }

    public void SetVolumeSFX(float _volume)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(_volume) * 20);
    }

    public void ReturnToPauseMenu()
    {
        pauseMenu.SetActive(true);
        audioMenu.SetActive(false);
        keyMapMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void OpenGraphics()
    {
        audioMenu.SetActive(false);
        keyMapMenu.SetActive(false);
        graphicsMenu.SetActive(true);
    }
    public void OpenAudio()
    {
        audioMenu.SetActive(true);
        keyMapMenu.SetActive(false);
        graphicsMenu.SetActive(false);
    }
    public void OpenKeyMap()
    {
        audioMenu.SetActive(false);
        keyMapMenu.SetActive(true);
        graphicsMenu.SetActive(false);
    }

    private void MasterTextValue(float _value)
    {
        _value = Mathf.Round(_value * 100);
        string textValue = _value.ToString();

        masterText.text = textValue;
    }

    private void BGMTextValue(float _value)
    {
        _value = Mathf.Round(_value * 100);
        string textValue = _value.ToString();

        bgmText.text = textValue;
    }

    private void SFXTextValue(float _value)
    {
        _value = Mathf.Round(_value * 100);
        string textValue = _value.ToString();

        sfxText.text = textValue;
    }
}
