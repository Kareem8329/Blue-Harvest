using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 12f;

    void start()
    {
        Jump();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}