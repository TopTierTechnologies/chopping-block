using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject foodItemPrefab;
    [SerializeField] private float baseSpawnInterval = 1.5f;
    [SerializeField] private float minSpawnInterval = 0.3f; // Fastest it can get
    [SerializeField] private float spawnRangeX = 3f;
    [SerializeField] private float spawnY = -15f;
    
    [Header("Difficulty Progression")]
    [SerializeField] private int scorePerDifficultyIncrease = 50; // Speeds up every 50 points
    [SerializeField] private float intervalDecreaseAmount = 0.05f; // Reduces interval by this much
    
    [Header("Physics Settings")]
    [SerializeField] private float minForce = 8f;
    [SerializeField] private float maxForce = 12f;
    [SerializeField] private float torqueAmount = 5f;

    private bool isSpawning = false;
    private float currentSpawnInterval;
    private int lastDifficultyScore = 0;

    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            currentSpawnInterval = baseSpawnInterval;
            lastDifficultyScore = 0;
            StartCoroutine(SpawnRoutine());
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    public void UpdateDifficulty(int currentScore)
    {
        // Check if we've crossed a difficulty threshold
        int difficultyLevel = currentScore / scorePerDifficultyIncrease;
        int lastDifficultyLevel = lastDifficultyScore / scorePerDifficultyIncrease;
        
        if (difficultyLevel > lastDifficultyLevel)
        {
            // Increase difficulty
            currentSpawnInterval -= intervalDecreaseAmount;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
            
            lastDifficultyScore = currentScore;
            
            Debug.Log($"Difficulty increased! New spawn interval: {currentSpawnInterval:F2}s");
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (isSpawning)
        {
            SpawnFood();
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }

    void SpawnFood()
    {
        // Get unlocked foods
        List<FoodData> unlockedFoods = FoodManager.Instance.GetUnlockedFoods();
        
        if (unlockedFoods.Count == 0)
        {
            Debug.LogWarning("No unlocked foods available!");
            return;
        }

        // Random spawn position
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Random food from unlocked foods
        FoodData randomFood = unlockedFoods[Random.Range(0, unlockedFoods.Count)];
        
        // Instantiate food
        GameObject food = Instantiate(foodItemPrefab, spawnPosition, Quaternion.identity);
        
        // Initialize with food data
        FoodItem foodItem = food.GetComponent<FoodItem>();
        if (foodItem != null)
        {
            foodItem.Initialize(randomFood);
        }

        // Add upward force
        Rigidbody2D rb = food.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float randomForce = Random.Range(minForce, maxForce);
            rb.AddForce(Vector2.up * randomForce, ForceMode2D.Impulse);
            
            // Add rotation
            rb.AddTorque(Random.Range(-torqueAmount, torqueAmount));
        }
    }
    
    // Get current spawn rate for UI display (optional)
    public float GetCurrentSpawnInterval()
    {
        return currentSpawnInterval;
    }
}