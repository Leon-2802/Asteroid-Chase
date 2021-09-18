using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorManager : MonoBehaviour
{
    public static meteorManager instance;
    [SerializeField] private MeteorPooler meteorPooler = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private string[] meteorPrefabs = null;
    [SerializeField] private string magneticPrefab = "";
    public int magneticProbability = 0;
    [SerializeField] private Transform[] spawns = null;
    [SerializeField] private float spawnTime = 0f;
    [SerializeField] public bool bossPhase = false;
    private float spawnInterval;
    public bool magneticPull = false;
    private bool spawn4Stage3 = false;
    private bool spawn4Stage4 = false;

    private void Awake() 
    {
        instance = this;
    }
    void Start() {
        spawnInterval = spawnTime;
        SpawnFourTimes();
    }
    void SpawnFourTimes()
    {
        for(int i = 0; i < 4; i++) {
            spawnMeteor();
        }
    }

    void Update()
    {
        CheckForBossFight();
        if(bossPhase == false) 
        {
            spawnInterval -= Time.deltaTime;
            if(spawnInterval <= 0) {
                spawnInterval = spawnTime;
                spawnMeteor();
            }
        }

        if(gameManager.currentStage == GameManager.Stages.STAGE_3) {
            if(spawn4Stage3 == false) {
                SpawnFourTimes();
                spawn4Stage3 = true;
            }
        }
        if(gameManager.currentStage == GameManager.Stages.STAGE_4) {
            if(spawn4Stage4 == false) {
                SpawnFourTimes();
                spawn4Stage4 = true;
            }
        }
    }

    void CheckForBossFight()
    {
        for(int i = 0; i < gameManager.bossFight.Length; i++) {
            if(gameManager.bossFight[i] == true) 
                bossPhase = true;
            else
                bossPhase = false;
        }
    }

    public void spawnMeteor() 
    {
        if(gameManager.currentStage == GameManager.Stages.STAGE_1)
            SpawnMeteorStage1();
        else
            SpawnMeteorStageLater();
    }
    private void SpawnMeteorStage1()
    {
        int randSpawn = Random.Range(0, spawns.Length);
        int randMeteor = Random.Range(0, meteorPrefabs.Length);
        meteorPooler.spawnMeteorsFromPool(meteorPrefabs[randMeteor], spawns[randSpawn].position, Quaternion.identity);
    }
    private void SpawnMeteorStageLater()
    {
        int magneticRandom = UnityEngine.Random.Range(0, magneticProbability);
        int randSpawn = Random.Range(0, spawns.Length);
        if(magneticRandom == (magneticProbability - 1))
            meteorPooler.spawnMeteorsFromPool(magneticPrefab, spawns[randSpawn].position, Quaternion.identity);
        else {
            int randMeteor = Random.Range(0, meteorPrefabs.Length);
            meteorPooler.spawnMeteorsFromPool(meteorPrefabs[randMeteor], spawns[randSpawn].position, Quaternion.identity);
        }
    }

    public void spawnChildMeteor(string tag) {
        int randSpawn = Random.Range(0, spawns.Length);
        meteorPooler.spawnMeteorsFromPool(tag, spawns[randSpawn].position, Quaternion.identity);
    }

    public void meteorRelocated(string tag, GameObject meteor) {
        meteorPooler.MeteorDestroyed(tag, meteor);
    }
}
