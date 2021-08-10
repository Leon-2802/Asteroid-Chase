using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    [SerializeField] private EnemyManager mainScript = null;
    [SerializeField] private string enemyPrefab = "";
    [SerializeField] private Transform[] spawns = null;
    public float spawnInt;
    [SerializeField] private float firstSpawn = 5f;
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
        int spawnIndex = UnityEngine.Random.Range(0, spawns.Length);
        mainScript.enemyPooler.SpawnEnemiesFromPool(enemyPrefab, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
    }
    public void ResetActiveSpawnInt()
    {
        activeSpawnInt = spawnInt;
    }
}
