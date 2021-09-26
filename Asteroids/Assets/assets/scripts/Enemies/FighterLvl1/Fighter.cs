using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Enemy
{
    [SerializeField] private shipController shipController;
    private bool started = false;

    void Start() 
    {
        shipController = shipController.instance;
        meteorPooler = MeteorPooler.Instance;
        target = shipController.gameObject.transform;
    }
    protected virtual void OnEnable() 
    {
        if(started)
            enemyList.enemies.Add(this.gameObject);
        started = true;
    }
}
