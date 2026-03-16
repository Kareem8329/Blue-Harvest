using UnityEditor;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("Ship")]
    public GameObject ship;

    private float leftCameraBoundary; // The area where the prefab will be spawned
    private float rightCameraBoundary; // The area where the prefab will be spawned
    private float leftShipBoundary; // The area where the prefab will be spawned
    private float rightShipBoundary; // The area where the prefab will be spawned

    public float fishSpawnInterval = 2f; // Time interval for spawning fish
    public float enemySpawnInterval = 4f; // Time interval for spawning enemies

    public GameObject enemyPrefab;

    private GameManagerScript gameManagerScript;
    private PlayerStats playerStats;

    [SerializeField] private FishDatabaseScriptableObject fishDatabase;

    void Start()
    {
        StartSpawning();
    }

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

        float BottomOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 0.3f;
        Vector3 spawnPosition = new Vector3(spawnXPosition, BottomOfScreen, 0);

        return spawnPosition;
    }

    void StartSpawning()
    {
            InvokeRepeating("SpawnFish", 1f, fishSpawnInterval);

            InvokeRepeating("SpawnEnemy", 2f, enemySpawnInterval);
    }

    void SpawnFish()
    {
        if (GameManagerScript.Instance.isDay)
        {
            float spawnChance = 0.7f * PlayerStats.luck; // Get a random value between 0 and 1
            if(Random.value < spawnChance)
            {
                Vector3 spawnPosition = getSpawnPosition();
                Rarity rarity = RollRarity();
                Debug.Log("Rolled rarity: " + rarity);

                FishScriptableObject fishData = RandomFishFromRarity(rarity);

                GameObject instantiatedFish = Instantiate(fishData.FishPrefab, spawnPosition, Quaternion.identity);
                instantiatedFish.GetComponent<FishBehavior>().Initialize(fishData);
            }
        }

    }

    public enum Rarity { Trash, Common, Rare, Legendary }

    FishScriptableObject RandomFishFromRarity(Rarity rarity)
    {
        int spawnIndex;
        switch (rarity)
        {   
            case Rarity.Trash:
                spawnIndex = Random.Range(0, fishDatabase.TrashFish.Count);
                return fishDatabase.TrashFish[spawnIndex];
            case Rarity.Common:
                spawnIndex = Random.Range(0, fishDatabase.CommonFish.Count);
                return fishDatabase.CommonFish[spawnIndex];
            case Rarity.Rare:
                spawnIndex = Random.Range(0, fishDatabase.RareFish.Count);
                return fishDatabase.RareFish[spawnIndex];
            case Rarity.Legendary:
                spawnIndex = Random.Range(0, fishDatabase.LegendaryFish.Count);
                return fishDatabase.LegendaryFish[spawnIndex];
        }
        return null; // Default case, should never reach here
    }



    Rarity RollRarity()
    {
        float rarityRoll = Mathf.Clamp(Random.value * PlayerStats.luck, 0.05f, 1f);

        if (rarityRoll < 0.3f) return Rarity.Trash;
        if (rarityRoll < 0.7f) return Rarity.Common;
        if (rarityRoll < 0.93f) return Rarity.Rare;
        return Rarity.Legendary;
    }

    void SpawnEnemy()
    {
        if (!GameManagerScript.Instance.isDay)
        {
            int wave = GameManagerScript.Instance.waveNumber;

            // number of enemies increases with wave
            int enemiesToSpawn = 1 + wave;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Vector3 spawnPosition = getSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

}