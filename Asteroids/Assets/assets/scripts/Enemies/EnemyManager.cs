using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyPooler enemyPooler;
    private GameManager gameManager;
    [SerializeField] private string[] enemyPrefabs = null;
    [SerializeField] private Transform[] spawns = null;

    //FighterLvl1:
    [SerializeField] private EnemySpawnHandler fighterLvl1Spawner;
    [SerializeField] private float fighterLvl1SpawnInt = 0f;

    //MissileLauncher:
    [SerializeField] private EnemySpawnHandler missileLauncherSpawner;
    public int missileMaxNumber = 3;
    [SerializeField] private float missileBossSpawnInt = 0f;
    [SerializeField] private float missileLauchnerSpawnInt = 0f;

    void Start()
    {
        enemyPooler = EnemyPooler.instance;
        gameManager = GameManager.instance;

        //fighterLvl1:
        fighterLvl1Spawner = this.gameObject.AddComponent<EnemySpawnHandler>();
        fighterLvl1Spawner.mainScript = this;
        fighterLvl1Spawner.enemyPrefab = enemyPrefabs[0];
        fighterLvl1Spawner.spawn = spawns[0];
        fighterLvl1Spawner.spawnInt = fighterLvl1SpawnInt;
        fighterLvl1Spawner.firstSpawn = fighterLvl1SpawnInt;

        //MissileLauncher:
        missileLauncherSpawner = this.gameObject.AddComponent<EnemySpawnHandler>();
        missileLauncherSpawner.enabled = false;
        missileLauncherSpawner.mainScript = this;
        missileLauncherSpawner.enemyPrefab = enemyPrefabs[1];
        missileLauncherSpawner.spawn = spawns[1];
        missileLauncherSpawner.spawnInt = missileLauchnerSpawnInt;
    }

    void Update()
    {
        switch(gameManager.currentStage)
        {
            case GameManager.Stages.STAGE_1:
                if(gameManager.bossFight[0] == true && gameManager.bossDefeated[0] == false) {
                    missileLauncherSpawner.spawnInt = missileBossSpawnInt;
                    missileLauncherSpawner.enabled = true; 
                    fighterLvl1Spawner.enabled = false;
                }
                else {
                    missileLauncherSpawner.spawnInt = missileLauchnerSpawnInt;
                    fighterLvl1Spawner.enabled = true;
                }
            break;
            case GameManager.Stages.STAGE_2:
                missileLauncherSpawner.spawnInt = missileLauchnerSpawnInt;
                // missileLauncherSpawner.ResetActiveSpawnInt();
                fighterLvl1Spawner.enabled = true;
            break;
        }
        
    }
}
