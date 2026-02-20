using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [Header("Food Properties")]
    [SerializeField] private FoodData foodData;
    
    [Header("Effects")]
    [SerializeField] private GameObject tapEffectPrefab;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool hasBeenTapped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (foodData != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = foodData.foodSprite;
        }
    }

    public void Initialize(FoodData data)
    {
        foodData = data;
        
        if (spriteRenderer != null && foodData != null)
        {
            spriteRenderer.sprite = foodData.foodSprite;
        }
    }

    public void OnTapped()
    {
        if (hasBeenTapped) return;
        
        hasBeenTapped = true;

        // Play tap effect
        if (tapEffectPrefab != null)
        {
            Instantiate(tapEffectPrefab, transform.position, Quaternion.identity);
        }

        // Play sound
        AudioManager.Instance?.PlaySFX(AudioManager.Instance.tapSound);

        // Notify game manager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnFoodTapped(this);
        }

        // Destroy the food item
        Destroy(gameObject);
    }

    public string GetFoodName()
    {
        return foodData != null ? foodData.foodName : "Unknown";
    }

    public int GetPoints()
    {
        return foodData != null ? foodData.pointValue : 0;
    }

    public FoodData GetFoodData()
    {
        return foodData;
    }

    void OnBecameInvisible()
    {
        // If food falls off screen without being tapped
        if (!hasBeenTapped)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnFoodMissed(this);
            }
            Destroy(gameObject);
        }
    }
}