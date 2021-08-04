using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    public Enemy mainScript;
    private bool canShoot = true;
    private float shootInt;
    // private float backToIdle = 0.5f;
    void Update()
    {
        if(mainScript.targetSelected == true && canShoot == true) 
        {
            shootInt = mainScript.shootIntervall;
            shoot();
            // backToIdle -= Time.deltaTime;
            // if(backToIdle <= 0)
            //     mainScript.animator.SetTrigger("Idle");
        }
        
        if(canShoot == false)
        {
            shootInt -= Time.deltaTime;
             if(shootInt <= 0) {
                mainScript.targetSelected = false;
                canShoot = true;
             }
        }
    }

    void shoot()
    {
        canShoot = false;
        // backToIdle = 0.5f;
        // mainScript.animator.SetTrigger("Shot");
        mainScript.meteorPooler.SpawnProjectileFromPool(mainScript.projectilePrefab, mainScript.projectileSpawn.position, mainScript.projectileSpawn.rotation);
    }
}
