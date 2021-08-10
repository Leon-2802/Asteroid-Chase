using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyPooler enemyPooler;
    private GameManager gameManager;
    [SerializeField] private EnemySpawnHandler fighterLvl1Spawner = null;
    [SerializeField] private EnemySpawnHandler missileLauncherSpawner = null;
    [SerializeField] private float missileBossSpawnInt = 0f;
    [SerializeField] private float missileLauncherSpawnInt = 0f;
    [SerializeField] private EnemySpawnHandler fighterLvl2Spawner = null;

    void Start()
    {
        enemyPooler = EnemyPooler.instance;
        gameManager = GameManager.instance;
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
                    missileLauncherSpawner.spawnInt = missileLauncherSpawnInt;
                    fighterLvl1Spawner.enabled = true;
                }
            break;
            case GameManager.Stages.STAGE_2:
                missileLauncherSpawner.spawnInt = missileLauncherSpawnInt;
                missileLauncherSpawner.enabled = false;
                fighterLvl1Spawner.enabled = true;
                fighterLvl2Spawner.enabled = true;
            break;
        }
        
    }
}
