using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public Transform enemySpawnPt;
    public float spawnRate = 10f;
    public float minY = -3f, maxY = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 7f, spawnRate);
    }
    void SpawnEnemy() {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(enemySpawnPt.position.x, randomY, 0);
        GameObject newEnemey = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Destroy(newEnemey, 10f);
    }
}
