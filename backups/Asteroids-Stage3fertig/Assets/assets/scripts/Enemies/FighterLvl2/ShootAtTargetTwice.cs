using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTargetTwice : ShootAtTarget
{
    public bool shot = false;
    [SerializeField] private Transform spawn1 = null;
    [SerializeField] private Transform spawn2 = null;
    
    protected override void shoot()
    {
        canShoot = false;
        mainScript.meteorPooler.SpawnProjectileFromPool(mainScript.projectilePrefab, spawn1.position, spawn1.rotation);
        mainScript.meteorPooler.SpawnProjectileFromPool(mainScript.projectilePrefab, spawn2.position, spawn2.rotation);
        shot = true;
    }
}
