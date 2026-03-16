using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{

    private GameManagerScript gameManagerScript;
     
    public float dayDuration = 60f; // Duration of a day in seconds
    private float daytimer = 0f;

    public TMP_Text waveText;
    public TMP_Text waveTextLoseScreen;

    public GameObject sunPrefab;
    public GameObject moonPrefab;

    public float spawnPlanetOffset;
    public float spawnPlanetYPosition;

    private float leftBoundary;
    private float rightBoundary;

    private float startX;
    private float endX;

    private GameObject currentPlanet;

    void Start()
    {
        leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        endX = rightBoundary + spawnPlanetOffset;
        startX = leftBoundary - spawnPlanetOffset;

        spawnPlanet();
    }

    void spawnPlanet()
    {

        Vector3 spawnPosition = new Vector3(startX, spawnPlanetYPosition, 0);

        if (GameManagerScript.Instance.isDay) // Spawn the sun
        {
            currentPlanet = Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Spawning the sun...");
        }
        else // spawn the moon
        {
            currentPlanet = Instantiate(moonPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Spawning the moon...");
            GameManagerScript.Instance.waveNumber++; // Increment wave number at the start of each night
        }

    }

    void Update()
    {
        daytimer += Time.deltaTime;

        waveText.text = GameManagerScript.Instance.waveNumber.ToString();
        waveTextLoseScreen.text = "Wave   " + GameManagerScript.Instance.waveNumber.ToString();

        if (currentPlanet != null)
        { 
            currentPlanet.transform.position = new Vector3(Mathf.Lerp(startX, endX, daytimer / dayDuration), spawnPlanetYPosition, 0);
        }

        if (daytimer >= dayDuration)
        {
            changeTime();
        }
    }

    void changeTime()
    {
        Debug.Log("Changing time of day...");
        if (currentPlanet != null)
        {
            Destroy(currentPlanet);
            spawnPlanet();     
        }

        //change the lighting setting to reflect the night

        daytimer = 0f; // Reset the timer
        GameManagerScript.Instance.ToggleDay(); // Toggle between day and night
    }

}
