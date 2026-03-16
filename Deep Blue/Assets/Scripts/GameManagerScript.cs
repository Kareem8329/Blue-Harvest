using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.Universal;

public class GameManagerScript : MonoBehaviour
{

     public static GameManagerScript Instance;


    [Header("UI Panels")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] Light2D globalLight;

    public GameObject notification;

    [Header("Music")]
    public AudioSource musicSource;
    public AudioClip dayMusic;
    public AudioClip nightMusic;

[Header("Night UI")]
[SerializeField] GameObject nightImage;

    public int waveNumber = 1;

    private bool isPaused = false;

void Awake()
{
    Instance = this;
    Debug.Log($"[GameManager] Awake — timeScale={Time.timeScale}");
}

void Start()
{
    Time.timeScale = 1f;
    Debug.Log($"[GameManager] Start — timeScale after reset={Time.timeScale}");
    if (gameOverScreen != null) gameOverScreen.SetActive(false);
    if (pauseScreen != null) pauseScreen.SetActive(false);
    if (nightImage != null) nightImage.SetActive(false);
}

public void RestartGame()
{
    Debug.Log($"[GameManager] RestartGame called — timeScale={Time.timeScale}");
    Time.timeScale = 1f;
    // Reset player stats
    PlayerStats.hp = 1;
    PlayerStats.damage = 1;
    PlayerStats.luck = 1f;
    PlayerStats.pierce = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public bool isDay = true; // Start with day

    public void Lose()
    {
        gameOverScreen.SetActive(true); // show game over UI
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void HideScreens()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
            return;
        }


        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        isPaused = false;
    }

    public void ToggleDay()
    {
        isDay = !isDay; // Toggle between day and night
        Debug.Log(" Time has changed. It is currently: " + (isDay ? "Day" : "Night"));
        UpdateMusic();
        UpdateNightUI();
    }

    void UpdateMusic()
    {
        if (isDay)
        {
            musicSource.clip = dayMusic;
        }
        else
        {
            musicSource.clip = nightMusic;
        }

        musicSource.Play();
    }

    void UpdateNightUI()
    {
        globalLight.intensity = isDay ? 1f : 0.2f; // Dim the light at night
        globalLight.color = isDay ? Color.white : new Color(0.5f, 0.5f, 1f); // Slightly bluish light at night
    }
    
    public void FishCaught(string fishName)
    {
        // Update text
     //   notification.GetComponent<TMP_Text>().text = $"You caught a {fishName}!";
      //  GameObject notificationInstance = Instantiate(notification, notification.transform.position, Quaternion.identity);
    //    Destroy(notificationInstance, 2f); // Destroy after 2 seconds
    }

}
