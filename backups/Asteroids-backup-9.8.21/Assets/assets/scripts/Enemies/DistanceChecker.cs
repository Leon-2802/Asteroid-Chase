using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public Enemy mainScript;

    void Update()
    {
        if(Vector2.Distance(mainScript.target.position, mainScript.enemyPos.position) < mainScript.attackRadius)
            mainScript.inRange = true;
        else
            mainScript.inRange = false;
    }
}
