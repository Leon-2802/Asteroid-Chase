using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipManager : WarshipManager
{
    [SerializeField] public GameManager gameManager = null;
    [SerializeField] private GameObject energyBallLauncher = null;
    [SerializeField] private SwarmLauncher swarmLauncher = null;
    [SerializeField] private float swarmInt = 3f;
    private float currentSwarmInt;
    void OnEnable()
    {
        currentSwarmInt = swarmInt;
    }

    protected override void Update()
    {
        if(currentHealth <= 0) {
            shipColliders.SetActive(false);
            flames.SetActive(false);
            sprite.enabled = false;
            explosion.SetActive(true);
            explosion.transform.position = this.transform.position;
            countdown -= Time.deltaTime;
            if(countdown <= 0) {
                bossManger.EndBossFight3();
            }
        }

        if(currentHealth <= healthAfterWeaponsDestroyed) {
            energyBallLauncher.SetActive(true);
        }

        currentSwarmInt -= Time.deltaTime;
        if(currentSwarmInt <= 0) {
            swarmLauncher.SpawnSwarm();
            currentSwarmInt = swarmInt;
        }
    }
}
