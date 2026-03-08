using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private float dayDuration = 60f; // Duration of a day in seconds
    private float daytimer = 0f;
    public static bool isDay = true; // Start with day

    public GameObject sunPrefab;
    public GameObject moonPrefab;

    public float spawnPlanetOffset;
    public float spawnPlanetYPosition;

    private float leftBoundary;
    private float rightBoundary;

void Start()
    {
        leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    void spawnPlanet()
    {
        // Spawn the sun
        if (isDay)
        {
            Instantiate(sunPrefab, new Vector3(leftBoundary + spawnPlanetOffset, spawnPlanetYPosition, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(moonPrefab, new Vector3(leftBoundary + spawnPlanetOffset, spawnPlanetYPosition, 0), Quaternion.identity);
        }
        Instantiate(sunPrefab, new Vector3(leftBoundary + spawnPlanetOffset, spawnPlanetYPosition, 0), Quaternion.identity);

        //I want to move the sunmoon game object across the screen from right to left over the course of the day duration, and then destroy it at the end of the day duration, and then spawn a new one for the next day, and repeat this process indefinitely
    }

    void FixedUpdate()
    {
        daytimer += Time.deltaTime;

        sunPrefab.transform.position = new Vector3(Mathf.Lerp(rightBoundary, leftBoundary, daytimer / dayDuration), spawnPlanetYPosition, 0);

        if (daytimer >= dayDuration)
        {
            changeTime();
        }
    }

    void changeTime()
    {
        Destroy(sunPrefab);
        Destroy(moonPrefab);
        spawnPlanet();

        //change the lighting setting to reflect the night

        daytimer = 0f; // Reset the timer
        isDay = !isDay; // Toggle between day and night
    }

    void Lose()
    {
        // Handle game over logic here (e.g., show game over screen, restart game, etc.)
    }
    void RestartGame()
    {
        // Handle game restart logic here (e.g., reset player position, reset score, etc.)
    }
    void PauseGame()
    {
        // Handle game pause logic here (e.g., pause game, show pause screen, etc.)
    }
}
