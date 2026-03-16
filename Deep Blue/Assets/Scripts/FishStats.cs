//using System.Diagnostics;
using UnityEngine;

public class FishStats : MonoBehaviour
{

    [Header("Trigger Settings")]
    public string spearTag = "Spear";
    public LayerMask spearLayer;
 
 public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Fish hit: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag(spearTag))
        {
        
        /* HP buff
        if (hpEffect != 0 && PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.AddHealth(hpEffect);
        }

        // Damage buff (permanent)
        if (damageEffect != 0)
        {
            PlayerStats.damage += damageEffect;
        }
        */

        Destroy(gameObject);   
        }

    }
}