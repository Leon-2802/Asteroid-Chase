using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public EnemyManager mainScript;
    public string enemyPrefab;
    public Transform spawn;
    public int maxNumber;
    public float spawnInt;
    public float firstSpawn = 5f;
    private float activeSpawnInt;
    void Start()
    {
        activeSpawnInt = firstSpawn;
    }

    void Update()
    {
        activeSpawnInt -= Time.deltaTime;
        if(activeSpawnInt <= 0) {
            activeSpawnInt = spawnInt;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        mainScript.enemyPooler.SpawnEnemiesFromPool(enemyPrefab, spawn.position, spawn.rotation);
    }
    public void ResetActiveSpawnInt()
    {
        activeSpawnInt = spawnInt;
    }
}
