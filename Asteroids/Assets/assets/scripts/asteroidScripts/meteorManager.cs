using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorManager : MonoBehaviour
{
    MeteorPooler meteorPooler;
    [SerializeField] private string[] meteorPrefabs = null;
    [SerializeField] private Transform[] spawns = null;
    [SerializeField] private float spawnTime = 0f;
    private float spawnInterval;

    void Start() {
        meteorPooler = MeteorPooler.Instance;
        spawnInterval = spawnTime;

        for(int i = 0; i < 4; i++) {
            spawnMeteor();
        }
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if(spawnInterval <= 0) {
            spawnInterval = spawnTime;
            for(int i = 0; i < 1; i++) { 
                spawnMeteor();
            }
        }
    }

    public void spawnMeteor() 
    {
        int randMeteor = Random.Range(0, meteorPrefabs.Length);
        int randSpawn = Random.Range(0, spawns.Length);
        meteorPooler.spawnMeteorsFromPool(meteorPrefabs[randMeteor], spawns[randSpawn].position, Quaternion.identity);
    }

    public void spawnChildMeteor(string tag) {
        int randSpawn = Random.Range(0, spawns.Length);
        meteorPooler.spawnMeteorsFromPool(tag, spawns[randSpawn].position, Quaternion.identity);
    }

    public void meteorRelocated(string tag) {
        meteorPooler.ObjectDestroyed(tag);
    }
}
