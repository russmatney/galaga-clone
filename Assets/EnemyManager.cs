using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemyCount = 10;
    public float spawnEvery = 1f;
    public float spawnXRange = 8f;

    private float spawnNewTTL;
    private int enemiesSpawned = 0;
    private bool finishedSpawning = false;

    void Start() {
        spawnNewTTL = spawnEvery;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnNewTTL < 0) {
            if (enemiesSpawned < enemyCount) {
                SpawnEnemy();
                spawnNewTTL = spawnEvery;
            } else {
                if (!finishedSpawning)
                    Debug.Log("all enemies spawned!");
                finishedSpawning = true;
            }
        } else {
            spawnNewTTL -= Time.deltaTime;
        }
    }

    void SpawnEnemy() {
        // TODO get random spawn point from list/children
        Vector3 pos = transform.position;
        pos.x += Random.Range(-spawnXRange/2, spawnXRange/2);
        Debug.Log("enemy pos " + pos);
        GameObject new_enemy = Instantiate(enemyPrefab, pos, Quaternion.identity) as GameObject;
        // TODO modify enemy ship and health to add variety
        enemiesSpawned++;
    }
}
