using UnityEngine;
using TMPro; // Required for TextMeshProUGUI
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("Combat")]
    public int baseDamage = 1;
    public int currentDamage;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI damageText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentDamage = baseDamage;
    }

    public void AddDamage(int amount)
    {
        currentDamage += amount;
        UpdateDamageText();
    }

    private void UpdateDamageText()
    {
        if (damageText != null)
            damageText.text = "DMG: " + currentDamage;
    }

}