using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerManager : MothershipManager
{
    [SerializeField] public bool[] rowDestroyed = {false, false, false};
    [SerializeField] private GameObject healthbarUI = null;
    [SerializeField] private GameObject[] ionenKanonen = null;
    [SerializeField] private GameObject guns = null;
    private float currentSwarmInterval;
    
    void OnEnable()
    {
        currentSwarmInterval = swarmInt;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(rowDestroyed[0] == true && rowDestroyed[1] == true && rowDestroyed[2] == true) 
        {
            for(int i = 0; i < ionenKanonen.Length; i++) {
                ionenKanonen[i].SetActive(true);
            }

            healthbarUI.SetActive(true);
            shipColliders.SetActive(true);
            guns.SetActive(true);
            energyBallLauncher.SetActive(true);

            currentSwarmInterval -= Time.deltaTime;
            if(currentSwarmInterval <= 0) {
                swarmLauncher.SpawnSwarm();
                currentSwarmInterval = swarmInt;
            }
        }


        if(currentHealth <= 0) 
        {
            shipColliders.SetActive(false);
            flames.SetActive(false);
            sprite.enabled = false;
            explosion.SetActive(true);
            explosion.transform.position = this.transform.position;
            countdown -= Time.deltaTime;
            if(countdown <= 0) {
                bossManger.EndBossFight4();
            }
        }
    }
}
