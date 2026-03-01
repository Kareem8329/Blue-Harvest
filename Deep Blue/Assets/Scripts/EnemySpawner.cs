using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public float spawnInterval = 3f;

    private float timer;
    private DayNightController dayNight;

    private int maxEnemies = 5;

    void Start()
    {
        dayNight = FindObjectOfType<DayNightController>();
    }

    void Update()
    {
        if (dayNight == null || !dayNight.nightTime)
            return;

        // 👇 Count active enemies
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Transform spawn = Random.value > 0.5f ? spawnPoint1 : spawnPoint2;
        Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
    }
}