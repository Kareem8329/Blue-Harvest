using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [Header("Fish Prefabs (Assign 3)")]
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;

    [Header("Spawn Points (Assign 4 Empty GameObjects)")]
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    private float timer = 0f;
    private float checkInterval = 4f;

    private DayNightController dayNightController;

    void Start()
    {
        dayNightController = FindObjectOfType<DayNightController>();
    }

    void Update()
    {
        if (dayNightController != null && dayNightController.nightTime)
            return; // Stop spawning during night

        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;
            TrySpawnFish();
        }
    }

    void TrySpawnFish()
    {
        int Number1 = Random.Range(1, 11);
        int Number2 = Random.Range(1, 11);

        if (Number1 > Number2)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        int fishIndex = Random.Range(0, 3);
        GameObject selectedFish = fish1;
        if (fishIndex == 0) selectedFish = fish1;
        if (fishIndex == 1) selectedFish = fish2;
        if (fishIndex == 2) selectedFish = fish3;

        int spawnIndex = Random.Range(0, 4);
        Transform selectedSpawn = spawnPoint1;
        if (spawnIndex == 0) selectedSpawn = spawnPoint1;
        if (spawnIndex == 1) selectedSpawn = spawnPoint2;
        if (spawnIndex == 2) selectedSpawn = spawnPoint3;
        if (spawnIndex == 3) selectedSpawn = spawnPoint4;

        Instantiate(selectedFish, selectedSpawn.position, Quaternion.identity);
    }
}