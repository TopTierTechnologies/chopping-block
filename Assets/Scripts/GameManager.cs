using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;
    [SerializeField] private bool isPlaying = false;

    [Header("UI References")]
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject[] lifeIcons;

    [Header("Spawner")]
    [SerializeField] private FoodSpawner foodSpawner;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void StartGame()
    {
        isPlaying = true;
        score = 0;
        lives = 3;
        UpdateUI();

        if (foodSpawner != null)
        {
            foodSpawner.StartSpawning();
        }

        // Play gameplay music
        AudioManager.Instance?.PlayMusic(AudioManager.Instance.gameplayMusic);
    }

    public void OnFoodTapped(FoodItem food)
    {
         if (!isPlaying) 
    {
        Debug.Log("OnFoodTapped called but game is not playing!");
        return;
    }

    //Add score
    score += food.GetPoints();
    Debug.Log("Score increased to: " + score);
    UpdateUI();
     // Check for unlocks (THIS IS THE NEW LINE)
    FoodManager.Instance.CheckScoreUnlocks(score);
    }

    public void OnFoodMissed(FoodItem food)
    {
        if (!isPlaying) return;

        //Lose a life
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        //Update score
    if (scoreText != null)
    {
        scoreText.text = score.ToString();
        Debug.Log("Score UI updated to: " + score);
    }
    else
    {
        Debug.LogError("ScoreText is NULL! Not assigned in Inspector.");
    }

    //Update lives
    for (int i = 0; i < lifeIcons.Length; i++)
    {
        if (i < lives)
        {
            lifeIcons[i].SetActive(true);
        }
        else
        {
            lifeIcons[i].SetActive(false);
        }
    }
    }

    void GameOver()
{
    isPlaying = false;

    if (foodSpawner != null)
    {
        foodSpawner.StopSpawning();
    }

    // Play gentle game over sound (kid-friendly, not scary)
    AudioManager.Instance?.PlaySFX(AudioManager.Instance.gameOverSound);

    // Award coins based on score (1 coin per 10 points)
    int coinsEarned = score / 10;
    MainMenuManager.AddCoins(coinsEarned);

    Debug.Log("Game Over! Final Score: " + score + " | Coins Earned: " + coinsEarned);
    // TODO: Show game over screen with coins earned
}

    public bool IsPlaying()
    {
        return isPlaying;
    }
}