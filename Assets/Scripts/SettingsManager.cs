using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Controls")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Text muteButtonText;

    [Header("Graphics Controls")]
    [SerializeField] private Dropdown graphicsDropdown;

    [Header("Attribution Text")]
    [SerializeField] private Text attributionText;

    private const string ATTRIBUTION = "Music by Kevin MacLeod (incompetech.com)\n" +
                                       "Licensed under Creative Commons: By Attribution 4.0\n" +
                                       "Sound effects from Kenney.nl (CC0)";

    void Start()
    {
        LoadCurrentSettings();

        if (attributionText != null)
        {
            attributionText.text = ATTRIBUTION;
        }

        Debug.Log("SettingsManager initialized");
    }

    void LoadCurrentSettings()
    {
        if (AudioManager.Instance != null)
        {
            if (musicVolumeSlider != null)
            {
                musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();
                musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            }

            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = AudioManager.Instance.GetSFXVolume();
                sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
            }

            UpdateMuteButtonText();
        }

        if (graphicsDropdown != null)
        {
            graphicsDropdown.value = QualitySettings.GetQualityLevel();
            graphicsDropdown.onValueChanged.AddListener(OnGraphicsChanged);
        }
    }

    public void OnMusicVolumeChanged(float value)
    {
        AudioManager.Instance?.SetMusicVolume(value);
    }

    public void OnSFXVolumeChanged(float value)
    {
        AudioManager.Instance?.SetSFXVolume(value);
    }

    public void ToggleMute()
    {
        AudioManager.Instance?.ToggleMute();
        UpdateMuteButtonText();
    }

    public void OnGraphicsChanged(int index)
    {
        // 0 = Standard, 1 = Low Performance
        QualitySettings.SetQualityLevel(index == 0 ? QualitySettings.names.Length - 1 : 0);
        Debug.Log("Graphics quality set to: " + (index == 0 ? "Standard" : "Low Performance"));
    }

    void UpdateMuteButtonText()
    {
        if (muteButtonText != null && AudioManager.Instance != null)
        {
            muteButtonText.text = AudioManager.Instance.IsMuted() ? "Unmute Sound" : "Mute Sound";
        }
    }

    public void GoHome()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.buttonClickSound);
        SceneManager.LoadScene("MainMenu");
    }
}
