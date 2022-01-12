using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : ObjectPooler
{
    public static EnemyPooler instance;
    [SerializeField] private EnemyList enemyList = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private MeteorPooler meteorPooler = null;
    private void Awake() {
        instance = this;
    }

    protected override void Start() 
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            switch(pool.tag)
            {
                case "FighterLvl1":
                    for (int i = 0; i < pool.size; i++) { 
                        GameObject obj = Instantiate(pool.prefab);
                        obj.transform.parent = this.gameObject.transform;
                        obj.GetComponent<Fighter>().enemyList = enemyList;
                        obj.GetComponent<Fighter>().target = player;
                        obj.GetComponent<Fighter>().meteorPooler = meteorPooler;
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }
                    break;
                case "FighterLvl2":
                    for (int i = 0; i < pool.size; i++) { 
                        GameObject obj = Instantiate(pool.prefab);
                        obj.transform.parent = this.gameObject.transform;
                        obj.GetComponent<FighterLvl2>().enemyList = enemyList;
                        obj.GetComponent<FighterLvl2>().target = player;
                        obj.GetComponent<FighterLvl2>().meteorPooler = meteorPooler;
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }
                    break;
                case "MissileLauncher":
                    for (int i = 0; i < pool.size; i++) { 
                        GameObject obj = Instantiate(pool.prefab);
                        obj.transform.parent = this.gameObject.transform;
                        obj.GetComponent<MissileLauncher>().enemyList = enemyList;
                        obj.GetComponent<MissileLauncher>().target = player;
                        obj.GetComponent<MissileLauncher>().meteorPooler = meteorPooler;
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }
                    break;
                case "ExplosionSmall":
                case "MissileExplosion":
                    for (int i = 0; i < pool.size; i++) { 
                        GameObject obj = Instantiate(pool.prefab);
                        obj.transform.parent = this.gameObject.transform;
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }
                    break;

            }

            poolDictionary.Add(pool.tag, objectPool);
        }
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
