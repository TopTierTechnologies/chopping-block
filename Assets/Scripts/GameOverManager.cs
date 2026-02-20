using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text coinsEarnedText;

    private const string LAST_SCORE_KEY = "LastScore";
    private const string HIGH_SCORE_KEY = "HighScore";

    void Start()
    {
        LoadAndDisplayScores();
        AudioManager.Instance?.PlayMusic(AudioManager.Instance.menuMusic);
    }

    void LoadAndDisplayScores()
    {
        int lastScore = PlayerPrefs.GetInt(LAST_SCORE_KEY, 0);
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        int coinsEarned = lastScore / 10;

        if (finalScoreText != null)
        {
            finalScoreText.text = lastScore.ToString();
        }

        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }

        if (coinsEarnedText != null)
        {
            coinsEarnedText.text = "+ " + coinsEarned + " coins";
        }

        Debug.Log("GameOver screen loaded - Score: " + lastScore + " | High Score: " + highScore);
    }

    public void TryAgain()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.buttonClickSound);
        SceneManager.LoadScene("Gameplay");
    }

    public void NewGame()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.buttonClickSound);
        // Reset score tracking for fresh start
        PlayerPrefs.SetInt(LAST_SCORE_KEY, 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToMainMenu()
    {
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.buttonClickSound);
        SceneManager.LoadScene("MainMenu");
    }
}
