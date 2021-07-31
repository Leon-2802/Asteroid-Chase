using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public int numberOfActive;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton

    public static MeteorPooler Instance;
    
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

    #endregion

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

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void meteorDestroyed(string tag) 
    {
        foreach (Pool pool in pools) {
            if(pool.tag == tag) 
                pool.numberOfActive--;
        }
    }
}
