using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.0f;
    public float minX = -8f;
    public float maxX = 8f;

    private float nextSpawnTime;
    private bool spawningEnabled = true;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (!spawningEnabled) return;

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0f);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawning()
    {
        spawningEnabled = false;
    }
}