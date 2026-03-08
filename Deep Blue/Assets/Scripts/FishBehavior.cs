using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce = 12f;

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jump();
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
