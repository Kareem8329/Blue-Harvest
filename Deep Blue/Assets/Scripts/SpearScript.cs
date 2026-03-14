using UnityEngine;

public class SpearScript : MonoBehaviour
{
    private bool hasHit = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasHit) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            hasHit = true;

            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                int damage = PlayerStats.damage;
                enemy.TakeDamage(damage);
            }

            // Destroy spear after short delay
            Destroy(gameObject, 0.2f);
        }
    }
}