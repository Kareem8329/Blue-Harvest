using UnityEngine;

public class SpearScript : MonoBehaviour
{
    // How many enemies the spear can pierce before being destroyed.
    // Uses PlayerStats.pierce (float) but treats it as an integer count.
    private int remainingPierceHits = 1;

    void Start()
    {
        // Destroy spear after 5 seconds if it doesn't hit anything
        Destroy(gameObject, 5f);

        // Ensure spear can pierce based on player stat (minimum 1 hit)
        remainingPierceHits = Mathf.Max(1, Mathf.FloorToInt(PlayerStats.pierce));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingPierceHits <= 0)
            return;

        if (!collision.gameObject.CompareTag("Enemy"))
            return;

        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(PlayerStats.damage);
        }

        remainingPierceHits--;

        // If we've used up all pierce hits, disable further collisions and destroy the spear
        if (remainingPierceHits <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.2f);
        }
    }
}