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
    private float spawnInterval = 20f;

    void Start() {
        meteorPooler = MeteorPooler.Instance;

        for(int i = 0; i < 4; i++) {
            spawnMeteor(i);
        }
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if(spawnInterval <= 0) {
            spawnInterval = 20f;
            for(int i = 0; i < 4; i++) {
                spawnMeteor(i);
            }
        }
    }

    void spawnMeteor(int spawn) 
    {
        int randMeteor = Random.Range(0, meteorPrefabs.Length);
        // int randX = Random.Range(0, xValues.Length);
        // int randY = Random.Range(0, yValues.Length);
        meteorPooler.spawnMeteorsFromPool(meteorPrefabs[randMeteor], spawns[spawn].position, Quaternion.identity);
        // meteor.GetComponent<meteorMovement>().xValue = xValues[randX];
        // meteor.GetComponent<meteorMovement>().yValue = yValues[randY];
    }
}
