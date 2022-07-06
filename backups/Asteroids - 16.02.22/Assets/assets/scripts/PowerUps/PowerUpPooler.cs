using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPooler : ObjectPooler
{
    public static PowerUpPooler instance;
    [SerializeField] private PowerUpManager powerUpManager = null;
    [SerializeField] private MeteorPooler meteorPooler = null;
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private GameManager gameManager = null;

    [SerializeField] private Transform[] spawnsNorth = null;
    [SerializeField] private Transform[] spawnsEast = null;
    [SerializeField] private Transform[] spawnsSouth = null;
    [SerializeField] private Transform[] spawnsWest = null;
    void Awake()
    {
        instance = this;
    }
    protected override void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            if(pool.tag == "playerTurret") 
            {
                for (int i = 0; i < pool.size; i++) { 
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.parent = this.gameObject.transform;
                    obj.GetComponent<PlayerTurretShooting>().powerUpManager = powerUpManager;
                    obj.GetComponent<PlayerTurretShooting>().meteorPooler = meteorPooler;
                    obj.GetComponent<PlayerTurretHitPrc>().enemyPooler = enemyPooler;
                    obj.GetComponent<PlayerTurretHitPrc>().gameManager = gameManager;
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            } 
            else 
            {
                for (int i = 0; i < pool.size; i++) { 
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.parent = this.gameObject.transform;
                    obj.GetComponent<PowerUpMovement>().gameManager = gameManager;
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnPowerUpFromPool (string tag, Vector3 pos, Quaternion rot)
    {
        if(!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        objectToSpawn.GetComponent<PowerUpMovement>().spawnsNorth = spawnsNorth;
        objectToSpawn.GetComponent<PowerUpMovement>().spawnsEast = spawnsEast;
        objectToSpawn.GetComponent<PowerUpMovement>().spawnsSouth = spawnsSouth;
        objectToSpawn.GetComponent<PowerUpMovement>().spawnsWest = spawnsWest;
        objectToSpawn.GetComponent<PowerUpMovement>().spawnsAssigned = true;

        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    public GameObject SpawnTurretFromPool (string tag, Vector3 pos, Quaternion rot)
    {
        if(!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
