using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public EnemyPooler enemyPooler;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private meteorManager meteorManager = null;
    [SerializeField] private EnemySpawnHandler fighterLvl1Spawner = null;
    [SerializeField] private EnemySpawnHandler missileLauncherSpawner = null;
    [SerializeField] private float missileBossSpawnInt = 0f;
    [SerializeField] private float missileLauncherSpawnInt = 0f;
    [SerializeField] private EnemySpawnHandler fighterLvl2Spawner = null;


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
                if(gameManager.bossFight[1] == true && gameManager.bossDefeated[1] == false) {
                    fighterLvl1Spawner.enabled = false;
                    fighterLvl2Spawner.enabled = false;
                } else {
                    missileLauncherSpawner.spawnInt = missileLauncherSpawnInt;
                    missileLauncherSpawner.enabled = false;
                    fighterLvl1Spawner.enabled = true;
                    fighterLvl2Spawner.enabled = true;
                    meteorManager.magneticProbability = 7;
                }
            break;
            case GameManager.Stages.STAGE_3:
                missileLauncherSpawner.enabled = true;
                fighterLvl1Spawner.enabled = true;
                fighterLvl2Spawner.enabled = true;
                meteorManager.magneticProbability = 5;
                break;
        }
        
    }
}
