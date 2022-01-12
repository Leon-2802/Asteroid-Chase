using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Enemy
{
    private bool started = false;

    protected virtual void OnEnable() 
    {
        if(started)
            enemyList.enemies.Add(this.gameObject);
        started = true;
    }
}
