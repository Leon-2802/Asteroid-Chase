using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : ObjectPooler
{
    public static EnemyPooler instance;
    private void Awake() {
        instance = this;
    }

    public GameObject SpawnEnemiesFromPool(string tag, Vector3 pos, Quaternion rot) 
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
