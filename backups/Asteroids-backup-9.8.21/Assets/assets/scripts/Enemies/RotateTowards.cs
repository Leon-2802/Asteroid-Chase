using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Enemy mainScript; 
    public float pauseTime = 0.2f;
    private bool startPause = false;
    private float currentPauseTime;

    void OnEnable() {
        currentPauseTime = pauseTime;
    }
    void Update()
    {
        if(mainScript.inRange == true && mainScript.targetSelected == false && startPause == false)
        {
            Vector2 lookdir = mainScript.target.position - mainScript.enemyPos.position;
            float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
            mainScript.enemyRb.rotation = angle;
            startPause = true;
        }
        if(startPause == true) {
            currentPauseTime -= Time.deltaTime;
            if(currentPauseTime <= 0) {
                startPause = false;
                currentPauseTime = pauseTime;
                mainScript.targetSelected = true;
            }
        }
    }
}
