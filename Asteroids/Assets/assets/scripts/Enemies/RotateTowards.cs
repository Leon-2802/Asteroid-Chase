using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Enemy mainScript; 
    void Update()
    {
        if(mainScript.inRange == true && mainScript.targetSelected == false)
        {
            Vector2 lookdir = mainScript.target.position - mainScript.enemyPos.position;
            float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
            mainScript.enemyRb.rotation = angle;
            mainScript.targetSelected = true;
        }
    }
}
