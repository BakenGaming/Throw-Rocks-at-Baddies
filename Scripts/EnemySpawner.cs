using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    private int enemiesSpawned;
    private float timeToNextSpawn;
    private int pointToSpawnAt;
    private int lastPointSpawnedAt = 99;
    
    public float spawnCoolDown;
    public int maxSpawnedEnemies;
    


    private void Start()
    {
        timeToNextSpawn = spawnCoolDown;
        pointToSpawnAt = Random.Range(0, spawnPoints.Length);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxSpawnedEnemies)
        {
            if (timeToNextSpawn <= 0)
            {
                if (pointToSpawnAt == lastPointSpawnedAt)
                {
                    pointToSpawnAt = Random.Range(0, spawnPoints.Length);
                }
                SpawnEnemy(pointToSpawnAt);
                Debug.Log("TOTAL ENEMIES: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
                timeToNextSpawn = spawnCoolDown;
            }
            else
            {
                timeToNextSpawn -= Time.deltaTime;
            }
        }
    }

    private void SpawnEnemy(int _spawnPoint)
    {
        lastPointSpawnedAt = _spawnPoint;
        Instantiate(enemyPrefab, spawnPoints[_spawnPoint].transform.position, transform.rotation);
        pointToSpawnAt = Random.Range(0, spawnPoints.Length);
        return;
    }
}
