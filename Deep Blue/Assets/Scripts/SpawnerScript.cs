using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("Ship")]
    public GameObject ship;

    private float leftCameraBoundary; // The area where the prefab will be spawned
    private float rightCameraBoundary; // The area where the prefab will be spawned
    private float leftShipBoundary; // The area where the prefab will be spawned
    private float rightShipBoundary; // The area where the prefab will be spawned

    public float fishSpawnInterval = 1f; // Time interval for spawning fish
    public float enemySpawnInterval = 1f; // Time interval for spawning enemies

    private GameManagerScript gameManagerScript;

    public Vector3 getSpawnPosition()
    {

        leftCameraBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        rightCameraBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        leftShipBoundary = ship.GetComponent<Renderer>().bounds.min.x;
        rightShipBoundary = ship.GetComponent<Renderer>().bounds.max.x;

        float spawnXPosition;

        if (Random.value < 0.5f)
        {
            // Left side
            spawnXPosition = Random.Range(leftCameraBoundary +1f, leftShipBoundary);
        }
        else
        {
            // Right side
            spawnXPosition = Random.Range(rightShipBoundary, rightCameraBoundary -1f);
        }

        float spawnY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 1;
        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnY, 0);

        return spawnPosition;
    }

    void StartSpawning()
    {
        if (GameManagerScript.isDay)
        {
            InvokeRepeating("TrySpawnFish", 0f, fishSpawnInterval); // Start spawning fish every 4 seconds after a delay of 0 seconds
        }
        else
        {
            InvokeRepeating("TrySpawnEnemy", 0f, enemySpawnInterval); // Start spawning enemies every 6 seconds after a delay of 0 seconds
        }
    }

    void TrySpawnFish()
    {
        // try spawning a random fish keeping in mind the spawn chance of each fish type

        if(Random.value < 0.4f) // 80% chance to spawn a fish
        {
            SpawnFish("Common");
        }
        else if(Random.value < 0.425f) // 15% chance to spawn a fish
        {
            SpawnFish("Rare");
        }
        else // 5% chance to spawn a fish
        {
            SpawnFish("Legendary");
        }

    }

    void TrySpawnEnemy()
    {
        // try spawning a random enemy keeping in mind the spawn chance of each enemy type
    }

    void SpawnFish(string fishrarity)
    {
        Vector3 spawnPosition = getSpawnPosition();
        //  Instantiate(FishToSpawn[Random.Range(0, FishToSpawn.Length)], spawnPosition, Quaternion.identity);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = getSpawnPosition();
        //Instantiate(EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Length)], spawnPosition, Quaternion.identity);
    }
}