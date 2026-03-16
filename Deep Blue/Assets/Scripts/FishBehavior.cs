using System;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{

    public FishScriptableObject fishData { get; private set; }
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private string spearTag = "Spear";
    [SerializeField] private float jumpForce = 12f;
    private AudioSource audioSource;


    public void Initialize(FishScriptableObject data)
    { fishData = data; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = fishData.FishSprite;
        ApplyBehavior();
    }

    private void ApplyBehavior()
    {
        switch (fishData.FishBehavior)
        {
            case FishScriptableObject.BehaviorEnum.Jump:
                Jump();
                break;

            case FishScriptableObject.BehaviorEnum.DoubleJump:
                DoubleJump();
                break;

            case FishScriptableObject.BehaviorEnum.TripleJump:
                TripleJump();
                break;

            case FishScriptableObject.BehaviorEnum.Flying:
                Flying();
                break;
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void DoubleJump()
    {
        Jump();
        Invoke("Jump", 2f);
    }

    public void TripleJump()
    {
        DoubleJump();
        Invoke("Jump", 4f);
    }

    public void Flying()
    {
        rb.gravityScale = 0;
        rb.linearVelocityY = jumpForce*0.5f; // slower ascent
    }

    // Handle collision with the spear
     public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(spearTag))
        {
            ApplyAttribute();
            GameManagerScript.Instance.FishCaught(fishData.FishName);
            Destroy(gameObject);   
        }

    }

    public void ApplyAttribute()
    {
        switch (fishData.FishAttribute)
        {
            case FishScriptableObject.AttributeEnum.HPBuff:
                PlayerStats.hp += 1;
                break;

            case FishScriptableObject.AttributeEnum.BetterHPBuff:
                PlayerStats.hp += 3;
                break;

            case FishScriptableObject.AttributeEnum.DamageBuff:
                PlayerStats.damage += 1;
                break;

            case FishScriptableObject.AttributeEnum.BetterDamageBuff:
                PlayerStats.damage += 3;
                break;

            case FishScriptableObject.AttributeEnum.LuckBuff:
                PlayerStats.luck += 0.05f;
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
                break;

            case FishScriptableObject.AttributeEnum.PiercingSpear:
                PlayerStats.pierce += 1;
                break;
        }
    }
}
