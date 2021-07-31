using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorManager : MonoBehaviour
{
    MeteorPooler meteorPooler;
    [SerializeField] private string[] meteorPrefabs = null;
    // [SerializeField] private float[] xValues = null;
    // [SerializeField] private float[] yValues = null;
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
        // int randX = Random.Range(0, xValues.Length);
        // int randY = Random.Range(0, yValues.Length);
        meteorPooler.spawnMeteorsFromPool(meteorPrefabs[randMeteor], spawns[randSpawn].position, Quaternion.identity);
        // meteor.GetComponent<meteorMovement>().xValue = xValues[randX];
        // meteor.GetComponent<meteorMovement>().yValue = yValues[randY];
    }

    public void meteorRelocated(string tag) {
        meteorPooler.meteorDestroyed(tag);
    }
}
