using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    [SerializeField] private EnemyManager mainScript = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private string enemyPrefab = "";
    [SerializeField] private Transform[] spawns = null;
    public float spawnInt;
    [SerializeField] private float spawnIntStage3 = 0f;
    [SerializeField] private float spawnIntStage4 = 0f;
    [SerializeField] private float spawnIntStage5 = 0f;
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
            switch(gameManager.currentStage)
            {
                case GameManager.Stages.STAGE_1:
                case GameManager.Stages.STAGE_2:
                    activeSpawnInt = spawnInt;
                    break;
                case GameManager.Stages.STAGE_3:
                    spawnInt = spawnIntStage3;
                    activeSpawnInt = spawnInt;
                    break;
                case GameManager.Stages.STAGE_4:
                    spawnInt = spawnIntStage4;
                    activeSpawnInt = spawnInt;
                    break;
                case GameManager.Stages.STAGE_5:
                    spawnInt = spawnIntStage5;
                    activeSpawnInt = spawnInt;
                    break;
            }
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
