using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    #region Fields
    [Header("GameObjects")]
    [SerializeField] private GameObject mainMenu;
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

    [Header("Menu Audio")]
    [SerializeField] private AudioData confirmClip;
    [SerializeField] private AudioClip toggleClip;
    [SerializeField] private AudioClip denyClip;

    [Header("Components")]
    [SerializeField] private AudioMixer mixer;
    #endregion

    private void Awake()
    {
        settingsMenu.SetActive(false);
        windowedToggle.isOn = true;
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

    public void PlayGame()
    {
        SceneManager.LoadScene("Sascha");
    }

    public void SettingsMenu()
    {
        mainMenu.SetActive(false);
        audioMenu.SetActive(false);
        keyMapMenu.SetActive(false);
        graphicsMenu.SetActive(true);
        settingsMenu.SetActive(true);

        SoundRequest.Request(false, Vector3.zero, confirmClip, "SFXVol");
    }

    public void SettingsToMainMenu()
    {

        settingsMenu.SetActive(false);
        audioMenu.SetActive(false);
        keyMapMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        mainMenu.SetActive(true);
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
