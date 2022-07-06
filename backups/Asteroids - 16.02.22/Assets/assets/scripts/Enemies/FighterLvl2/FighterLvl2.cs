using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterLvl2 : Fighter
{
    [SerializeField] private ShootAtTargetTwice shootScript = null;
    [SerializeField] private CrossMovement moveScript = null;
    [SerializeField] private float stopInt = 0f;
    private float currentStopInt;
    private bool started2 = false;

    protected override void OnEnable() 
    {
        currentStopInt = stopInt;

        if(started2)
            enemyList.enemies.Add(this.gameObject);
        started2 = true;
    }

    void Update()
    {
        if(shootScript.shot == true) 
        {
            moveScript.move = true;
            currentStopInt -= Time.deltaTime;
            if(currentStopInt <= 0) {
                moveScript.move = false;
                currentStopInt = stopInt;
                shootScript.shot = false;
            } 
        }
    }
}
