using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("Prefabs to Spawn")]
    public GameObject[] FishToSpawn; // The Fishprefabs to spawn
    public GameObject[] EnemiesToSpawn; // The Enemy prefabs to spawn

    [Header("Ship")]
    public GameObject ship;

    public int num; 

    private float leftCameraBoundary; // The area where the prefab will be spawned
    private float rightCameraBoundary; // The area where the prefab will be spawned
    private float leftShipBoundary; // The area where the prefab will be spawned
    private float rightShipBoundary; // The area where the prefab will be spawned

    public float fishSpawnInterval = 4f; // Time interval for spawning fish
    public float enemySpawnInterval = 6f; // Time interval for spawning enemies

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
            spawnX = Random.Range(leftCameraBoundary +1f, leftShipBoundary);
        }
        else
        {
            // Right side
            spawnX = Random.Range(rightShipBoundary, rightCameraBoundary -1f);
        }

        float spawnY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 1;
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        return spawnPosition;
    }

    void StartSpawning()
    {
        if ( GameManagerScript.instance.Time == "day")
        {
            InvokeRepeating(TrySpawnFish, 0f, fishSpawnInterval); // Start spawning fish every 4 seconds after a delay of 2 seconds
        }
        else if (GameManagerScript.instance.Time == "night")
        {
            InvokeRepeating(TrySpawnEnemy, 0f, enemySpawnInterval); // Start spawning enemies every 6 seconds after a delay of 5 seconds
        }
    }

    void TrySpawnFish()
    {
        // try spawning a random fish keeping in mind the spawn chance of each fish type
    }

    void TrySpawnEnemy()
    {
        // try spawning a random enemy keeping in mind the spawn chance of each enemy type
    }

    void SpawnFish()
    {
        Vector3 spawnPosition = getSpawnPosition();
        Instantiate(FishToSpawn[Random.Range(0, FishToSpawn.Length)], spawnPosition, Quaternion.identity);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = getSpawnPosition();
        Instantiate(EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Length)], spawnPosition, Quaternion.identity);
    }

    void ChangeActiveShip(GameObject newShip)
    {
       ship = newShip;
    }
}
