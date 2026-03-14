using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float jumpForce = 12f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Apply behavior based on the fish's assigned behavior type
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void DoubleJump()
    {

    }
    public void TripleJump()
    {

    }
    public void Flying()
    {

    }
}
