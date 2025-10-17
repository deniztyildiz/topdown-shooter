using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The enemy prefab to be spawned.
    [SerializeField]
    private GameObject enemyPrefab;

    // The rate at which enemies spawn, in seconds.
    [SerializeField]
    private float spawnRate = 2.0f;

    private float spawnTimer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        spawnTimer = spawnRate; // Start the timer at the full rate
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || mainCamera == null)
        {
            Debug.LogError("Enemy Prefab or Main Camera is not set!");
            return;
        }

        // --- THIS IS THE CHANGED LOGIC ---

        // 1. Pick a random X and Y coordinate within the screen's viewport.
        // The viewport's coordinates go from (0,0) at the bottom-left to (1,1) at the top-right.
        float randomX = Random.value; // Random.value returns a float between 0.0 and 1.0
        float randomY = Random.value;

        Vector2 spawnPointViewport = new Vector2(randomX, randomY);

        // 2. Convert the random viewport point to world coordinates.
        Vector3 spawnPointWorld = mainCamera.ViewportToWorldPoint(spawnPointViewport);
        spawnPointWorld.z = 0; // Ensure Z is 0 for a 2D game.

        // 3. Instantiate the enemy at the calculated position.
        Instantiate(enemyPrefab, spawnPointWorld, Quaternion.identity);
    }
}