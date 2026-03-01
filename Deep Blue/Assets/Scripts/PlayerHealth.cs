using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int currentHealth = 1;
    [SerializeField] private int maxHealth = 5;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("I-Frames Settings")]
    public float iFrameDuration = 2f;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    public static PlayerHealth Instance;

[SerializeField] private GameObject youLostText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        UpdateHealthUI();
    }

    public void AddHealth(int amount)
    {
        if (currentHealth >= maxHealth) return;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
        
            Debug.Log("Player Dead");

            // Show "You Lost" text
            if (youLostText != null)
                youLostText.SetActive(true);

            // Immediately reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "HP: " + currentHealth;
    }

    IEnumerator IFrames()
    {
        isInvincible = true;
        float flashTime = 0.1f;
        float elapsed = 0f;

        while (elapsed < iFrameDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            elapsed += flashTime;
            yield return new WaitForSeconds(flashTime);
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }

    public void StartIFrames()
    {
        StartCoroutine(IFrames());
    }
}