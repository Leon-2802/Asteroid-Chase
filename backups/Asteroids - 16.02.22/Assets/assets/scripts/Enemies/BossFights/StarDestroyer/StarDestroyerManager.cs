using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerManager : WarshipManager
{
    [SerializeField] public GameManager gameManager = null;
    [SerializeField] public bool[] rowDestroyed = {false, false, false};
    [SerializeField] private GameObject[] ionenKanonen = null;
    [SerializeField] private GameObject energyBallLauncher = null;
    [SerializeField] private SwarmLauncher swarmLauncher = null;
    [SerializeField] private float swarmInt = 3f;
    private float currentSwarmInt;
    
    void OnEnable()
    {
        currentSwarmInt = swarmInt;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(rowDestroyed[0] == true && rowDestroyed[1] == true && rowDestroyed[2] == true) 
        {
            for(int i = 0; i < ionenKanonen.Length; i++) {
                ionenKanonen[i].SetActive(true);
            }

            energyBallLauncher.SetActive(true);

            currentSwarmInt -= Time.deltaTime;
            if(currentSwarmInt <= 0) {
                swarmLauncher.SpawnSwarm();
                currentSwarmInt = swarmInt;
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
