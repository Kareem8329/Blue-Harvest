using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text luckText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text pierceText;

    [SerializeField] private PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP   " + PlayerStats.hp;
        luckText.text = "Luck   " + PlayerStats.luck;
        damageText.text = "Dmg   " + PlayerStats.damage;
        pierceText.text = "Pierce   " + PlayerStats.pierce;
    }
}
