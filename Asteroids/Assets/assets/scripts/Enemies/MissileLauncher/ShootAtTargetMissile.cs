using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTargetMissile : ShootAtTarget
{
    public bool shot = false;
    void Start()
    {
        
    }

    protected override void shoot()
    {
        base.shoot();
        shot = true;
    }
}
