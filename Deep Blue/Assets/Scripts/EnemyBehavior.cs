using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehavior : MonoBehaviour
{
    [Header("Jump Settings")]
    public float launchForce = 20f;
    public float upwardMultiplier = 2.5f;

    [Header("Movement Settings")]
    public float airMoveSpeed = 4f;
    public float groundMoveSpeed = 2f;

    private Rigidbody2D rb;
    private Transform player;
    private float currentMoveSpeed;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        currentMoveSpeed = airMoveSpeed;

        LaunchTowardsPlayer();
    }

    void LaunchTowardsPlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        Vector2 force = new Vector2(direction.x, upwardMultiplier).normalized * launchForce;

        rb.AddForce(force, ForceMode2D.Impulse);
    }

void Update()
{
    if (player == null) return;

    float direction = Mathf.Sign(player.position.x - transform.position.x);

    rb.linearVelocity = new Vector2(direction * currentMoveSpeed, rb.linearVelocity.y);

    // Flip sprite based on movement direction
    Vector3 scale = transform.localScale;
    scale.x = Mathf.Abs(scale.x) * -direction;
    transform.localScale = scale;
}

    public float attackCooldown = 1.0f; // seconds between attacks
    private float lastAttackTime = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            currentMoveSpeed = groundMoveSpeed;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayerStats.hp -= 1;       // deal damage
            lastAttackTime = Time.time; // reset cooldown
        }
    }
}