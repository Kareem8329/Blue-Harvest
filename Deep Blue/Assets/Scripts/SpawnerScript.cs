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
    private PlayerStats playerStats;

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

        // Fish or no fish
        // If fish, which fish type
        // Spawn the fish randomly from the type of the fish
        // Everything should be multiplied by the luck stat of the player

    }

    void TrySpawnEnemy()
    {
        // Try spawning a random enemy keeping in mind the spawn chance of each enemy type
    }

    void SpawnFish()
    {
        Vector3 spawnPosition = getSpawnPosition();
        float spawnChance = 0.5f * PlayerStats.luck; // Get a random value between 0 and 1
        if(Random.value < spawnChance)
        {
            // Spawn a fish at the spawn position with a random fish with random rarity
        }
    }

    public enum Rarity { Trash, Common, Rare, Legendary }

    Rarity RollRarity()
    {
        float rarityRoll = Mathf.Clamp(Random.value * PlayerStats.luck, 0f, 1f);

        if (rarityRoll < 0.2f) return Rarity.Trash;
        if (rarityRoll < 0.6f) return Rarity.Common;
        if (rarityRoll < 0.9f) return Rarity.Rare;
        return Rarity.Legendary;
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = getSpawnPosition();
        //Instantiate(EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Length)], spawnPosition, Quaternion.identity);
    }
}