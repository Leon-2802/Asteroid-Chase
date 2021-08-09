using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    [SerializeField] protected Enemy mainScript = null;
    [SerializeField] protected float shootInt = 0;
    protected float currentShootInt;
    protected bool canShoot = false;

    void Update()
    {
        if(mainScript.targetSelected == true && canShoot == true) 
        {
            currentShootInt = shootInt;
            shoot();
        }
        
        if(canShoot == false)
        {
            currentShootInt -= Time.deltaTime;
             if(currentShootInt <= 0) {
                mainScript.targetSelected = false;
                canShoot = true;
             }
        }
    }

    protected virtual void shoot()
    {
        canShoot = false;
        mainScript.meteorPooler.SpawnProjectileFromPool(mainScript.projectilePrefab, mainScript.projectileSpawn.position, mainScript.projectileSpawn.rotation);
    }
}
