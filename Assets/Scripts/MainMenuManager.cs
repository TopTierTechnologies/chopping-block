using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("User Info")]
    [SerializeField] private int userCoins = 25;
    [SerializeField] private Text coinsText;

    void Start()
    {
        // Load user coins from saved data later
        LoadUserData();
        UpdateCoinsDisplay();

        // Play menu music
        AudioManager.Instance?.PlayMusic(AudioManager.Instance.menuMusic);
    }

    public void PlayGame()
    {
        // Load the gameplay scene
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenAccount()
    {
        Debug.Log("Account screen - To be implemented");
        // TODO: Open account screen
    }

    public void OpenTrophyCase()
    {
        SceneManager.LoadScene("TrophyCase");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ToggleSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ToggleMute();
        }
        else
        {
            Debug.LogWarning("AudioManager not found - cannot toggle sound");
        }
    }

    void UpdateCoinsDisplay()
    {
        if (coinsText != null)
        {
            coinsText.text = userCoins.ToString();
        }
    }

    void LoadUserData()
    {
        // Load coins from PlayerPrefs (saved data)
        if (PlayerPrefs.HasKey("UserCoins"))
        {
            userCoins = PlayerPrefs.GetInt("UserCoins");
        }
        else
        {
            userCoins = 25; // Starting coins
            PlayerPrefs.SetInt("UserCoins", userCoins);
        }
    }

    public static void AddCoins(int amount)
    {
        int currentCoins = PlayerPrefs.GetInt("UserCoins", 0);
        currentCoins += amount;
        PlayerPrefs.SetInt("UserCoins", currentCoins);
        PlayerPrefs.Save();
    }

    public static int GetCoins()
    {
        return PlayerPrefs.GetInt("UserCoins", 25);
    }
}