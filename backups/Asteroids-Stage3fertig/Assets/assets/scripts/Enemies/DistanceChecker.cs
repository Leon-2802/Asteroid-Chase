using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    [SerializeField] private float attackRadius = 0f;

    void Update()
    {
        if(Vector2.Distance(mainScript.target.position, mainScript.enemyPos.position) < attackRadius)
            mainScript.inRange = true;
        else
            mainScript.inRange = false;
    }
}
