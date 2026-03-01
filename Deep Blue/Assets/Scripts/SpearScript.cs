using UnityEngine;

public class SpearScript : MonoBehaviour
{
    private bool hasHit = false;

    private void Start()
    {
        Debug.Log("aaaaa");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");

        if (hasHit) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            hasHit = true;

            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null && PlayerStats.Instance != null)
            {
                int finalDamage = PlayerStats.Instance.currentDamage;
                enemy.TakeDamage(finalDamage);

                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                }
            }
            // Destroy spear after short delay
            Destroy(gameObject, 0.5f);
        }
    }
}