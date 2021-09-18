using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private float spawnInt = 0f;
    private float currentSpawnInt;
    [SerializeField] private GameObject healthPrefab = null;
    [SerializeField] private Transform[] spawns = null;
    
    void Start()
    {
        currentSpawnInt = spawnInt;
    }

    void Update()
    {
        currentSpawnInt -= Time.deltaTime;
        if(currentSpawnInt <= 0)
        {
            int index = UnityEngine.Random.Range(0, spawns.Length);
            healthPrefab.transform.position = spawns[index].position;
            healthPrefab.SetActive(true);
            currentSpawnInt = spawnInt;
        }
    }
}
