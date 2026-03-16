using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Player Changing Stats")]
    public static int damage = 1;
    public static int hp = 1;
    public static float luck = 1f;
    public static float pierce = 1f;

    [Header("Player Static Stats")]
    public static float jumpForce = 12f;
    public static float speed = 5f;

    void Start()
    {
        GameManagerScript.Instance.HideScreens();
        Time.timeScale = 1f; // Ensure time is running when the game starts
    }

    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Player Dead");
            GameManagerScript.Instance.Lose();
        }
    }
}