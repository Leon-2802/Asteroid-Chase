﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPooler : ObjectPooler
{
    public static MeteorPooler Instance;
    [SerializeField] private Transform player = null;
    
    private void Awake() 
    {
        Instance = this;

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) { 
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    protected override void Start() {}

    public GameObject spawnMeteorsFromPool (string tag, Vector3 pos, Quaternion rot) 
    {
        if(!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        foreach (Pool pool in pools) {
            if(pool.size <= pool.numberOfActive) {
                Debug.Log("All elements in pool with tag " + tag + " are in use.");
                return null; 
            }
        }

        foreach (Pool pool in pools) {
            if(pool.tag == tag) 
                pool.numberOfActive++;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;
        objectToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        //Turret aktivieren wenn Random-Zahl stimmt: <---
        string objectTag = objectToSpawn.GetComponent<meteorMovement>().objectTag;
        if(objectTag == "big1" || objectTag == "big2" || objectTag == "big3")
        {
            int zufall = Random.Range(0, 8);
            if(zufall == 2) {
                objectToSpawn.transform.GetChild(0).gameObject.SetActive(true);
                objectToSpawn.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<EnemyTurret>().target = player;
                objectToSpawn.GetComponent<SpriteRenderer>().sortingLayerName = "TurretAsteroids";
            }
        }
        //--->

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public GameObject SpawnProjectileFromPool (string tag, Vector3 pos, Quaternion rot)
    {
        if(!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        foreach (Pool pool in pools) {
            if(pool.size <= pool.numberOfActive) {
                Debug.Log("All elements in pool with tag " + tag + " are in use.");
                return null; 
            }
        }

        foreach (Pool pool in pools) {
            if(pool.tag == tag) 
                pool.numberOfActive++;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
