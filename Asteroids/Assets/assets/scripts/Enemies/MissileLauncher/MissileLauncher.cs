using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : Enemy
{
    [SerializeField] private ShootAtTargetMissile shootAtTargetMissile = null;
    [SerializeField] private FlyTowardsMovement movement = null;
    private bool started = false;

    void OnEnable() 
    {
        if(started) 
        {
            movement.target = target.position;
            enemyList.enemies.Add(this.gameObject);
        }
        started = true;
    }

    void Update() 
    {
        if(shootAtTargetMissile.shot == true) {
            shootAtTargetMissile.shot = false;
            movement.SetMoveInt();
            movement.target = target.position;
        }
    }
}
