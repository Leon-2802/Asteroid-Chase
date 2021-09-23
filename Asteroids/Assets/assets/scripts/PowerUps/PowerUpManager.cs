using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private float spawnInt = 0f;
    private float currentSpawnInt;
    [SerializeField] private PowerUpPooler powerUpPooler = null;
    [SerializeField] private Transform[] spawns = null;
    [SerializeField] public List<Transform> targets = null;
    private bool bossPhase = false;
    
    void Start()
    {
        currentSpawnInt = spawnInt;
    }

    void Update()
    {
        CheckForBossFight();
        currentSpawnInt -= Time.deltaTime;
        if(currentSpawnInt <= 0)
        {
            int index = UnityEngine.Random.Range(0, spawns.Length);
            int whichPrefab = UnityEngine.Random.Range(0, 12);
            if(whichPrefab >= 0 && whichPrefab < 3 && bossPhase == false) {
                powerUpPooler.SpawnPowerUpFromPool("health", spawns[index].position, spawns[index].rotation);
                currentSpawnInt = spawnInt; 
            }
            else if(whichPrefab >= 3 && whichPrefab < 6 && bossPhase == false) {
                powerUpPooler.SpawnPowerUpFromPool("turretCard", spawns[index].position, spawns[index].rotation);
                currentSpawnInt = spawnInt; 
            }
            else if(whichPrefab >= 6 && whichPrefab < 8 && bossPhase == false) {
                powerUpPooler.SpawnPowerUpFromPool("shield", spawns[index].position, spawns[index].rotation);
                currentSpawnInt = spawnInt;
            }
            else if(whichPrefab >= 8 && whichPrefab < 10 && bossPhase == false) {
                powerUpPooler.SpawnPowerUpFromPool("swarmCard", spawns[index].position, spawns[index].rotation);
                currentSpawnInt = spawnInt;
            }
            else {
               currentSpawnInt = spawnInt; 
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
}
