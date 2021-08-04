using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyPooler enemyPooler;
    [SerializeField] private string[] enemyPrefabs = null;
    [SerializeField] private Transform[] spawns = null;
    //FighterLvl1:
    [SerializeField] private EnemySpawnHandler fighterLvl1Spawner;
    [SerializeField] private float fighterLvl1SpawnInt = 0f;
    void Start()
    {
        enemyPooler = EnemyPooler.instance;

        //fighterLvl1:
        fighterLvl1Spawner = this.gameObject.AddComponent<EnemySpawnHandler>();
        fighterLvl1Spawner.mainScript = this;
        fighterLvl1Spawner.enemyPrefab = enemyPrefabs[0];
        fighterLvl1Spawner.spawn = spawns[0];
        fighterLvl1Spawner.spawnInt = fighterLvl1SpawnInt;
    }

    void Update()
    {

    }
}
