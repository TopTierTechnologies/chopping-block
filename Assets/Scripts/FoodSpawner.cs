using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject foodItemPrefab; // Generic prefab with FoodItem script
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float spawnRangeX = 3f;
    [SerializeField] private float spawnY = -15f;
    
    [Header("Physics Settings")]
    [SerializeField] private float minForce = 8f;
    [SerializeField] private float maxForce = 12f;
    [SerializeField] private float torqueAmount = 5f;

    private bool isSpawning = false;

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnRoutine());
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    IEnumerator SpawnRoutine()
    {
        while (isSpawning)
        {
            SpawnFood();
            yield return new WaitForSeconds(spawnInterval);
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
}