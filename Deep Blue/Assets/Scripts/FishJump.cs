using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 12f;

    [Header("Water Physics")]
  //  [SerializeField] private float airDrag = 0f;
    [SerializeField] private float waterGravityMultiplier = 2f;
   // [SerializeField] private float airGravityScale = 1f;
    [SerializeField] private float forceMultiplier = 3f;
    private bool isInWater;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
      //  rb.linearDamping = airDrag; // Unity 6 uses linearDamping
    }

    void Start()
    {
        Jump();
        Debug.Log("hi");
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(0f, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.CompareTag("Water"))
       // {
            //isInWater = true;
         //   Debug.Log("in water");
          //  ApplyWaterPhysics();
       // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.AddForce(Vector2.up * jumpForce * forceMultiplier, ForceMode2D.Impulse);
            Debug.Log("plop");
          //  ApplyAirPhysics();
        }
    }

  //  void ApplyWaterPhysics()
  //  {
  //      rb.gravityScale = rb.gravityScale * waterGravityMultiplier;
  //  }

  //  void ApplyAirPhysics()
    //{
        //rb.linearDamping = airDrag;
      //  rb.gravityScale = airGravityScale;
  //  }
}