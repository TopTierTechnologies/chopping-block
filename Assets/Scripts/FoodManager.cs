using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FoodManager : MonoBehaviour
{
    public static FoodManager Instance;
    
    [Header("Food Database")]
    public List<FoodData> allFoods = new List<FoodData>();
    
    private const string UNLOCK_PREFIX = "Food_Unlocked_";
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        LoadAllFoodData();
        LoadUnlockStates();
    }
    
    void LoadAllFoodData()
    {
        // Load all food data from Resources folder
        FoodData[] foods = Resources.LoadAll<FoodData>("FoodData");
        allFoods = foods.ToList();
        Debug.Log($"Loaded {allFoods.Count} food items");
    }
    
    void LoadUnlockStates()
    {
        foreach (FoodData food in allFoods)
        {
            // Load unlock state from PlayerPrefs
            food.isUnlocked = PlayerPrefs.GetInt(UNLOCK_PREFIX + food.foodName, food.isUnlocked ? 1 : 0) == 1;
        }
    }
    
    public void UnlockFood(FoodData food)
    {
        if (food.isUnlocked) return;
        
        food.isUnlocked = true;
        PlayerPrefs.SetInt(UNLOCK_PREFIX + food.foodName, 1);
        PlayerPrefs.Save();
        
        Debug.Log($"Unlocked: {food.foodName}");
        
        // Show unlock banner
        UnlockBannerManager.Instance?.ShowUnlockBanner(food);
    }
    
    public bool TryUnlockWithCoins(FoodData food)
    {
        if (food.isUnlocked) return false;
        
        int currentCoins = MainMenuManager.GetCoins();
        
        if (currentCoins >= food.coinCost)
        {
            // Deduct coins
            PlayerPrefs.SetInt("UserCoins", currentCoins - food.coinCost);
            PlayerPrefs.Save();
            
            UnlockFood(food);
            return true;
        }
        
        return false;
    }
    
    public void CheckScoreUnlocks(int currentScore)
    {
        foreach (FoodData food in allFoods)
        {
            if (!food.isUnlocked && food.requiredScore > 0 && currentScore >= food.requiredScore)
            {
                UnlockFood(food);
            }
        }
    }
    
    public List<FoodData> GetUnlockedFoods()
    {
        return allFoods.Where(f => f.isUnlocked).ToList();
    }
    
    public List<FoodData> GetLockedFoods()
    {
        return allFoods.Where(f => !f.isUnlocked).ToList();
    }
    
    public List<FoodData> GetFoodsBySeason(string season)
    {
        return allFoods.Where(f => f.season == season).ToList();
    }
}