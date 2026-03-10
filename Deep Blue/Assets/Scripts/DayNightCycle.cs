using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    private GameManagerScript gameManagerScript;
     
    public float dayDuration = 60f; // Duration of a day in seconds
    private float daytimer = 0f;

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

        startX = rightBoundary + spawnPlanetOffset;
        endX = leftBoundary - spawnPlanetOffset;

        spawnPlanet();
    }

    void spawnPlanet()
    {

        Vector3 spawnPosition = new Vector3(startX, spawnPlanetYPosition, 0);

        if (GameManagerScript.isDay) // Spawn the sun
        {
            currentPlanet = Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
        }
        else // spawn the moon
        {
            currentPlanet = Instantiate(moonPrefab, spawnPosition, Quaternion.identity);
        }

    }

    void Update()
    {
        daytimer += Time.deltaTime;

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
        if (currentPlanet != null)
        {
            Destroy(currentPlanet);
            spawnPlanet();     
        }

        //change the lighting setting to reflect the night

        daytimer = 0f; // Reset the timer
        GameManagerScript.isDay = !GameManagerScript.isDay; // Toggle between day and night
    }

}
