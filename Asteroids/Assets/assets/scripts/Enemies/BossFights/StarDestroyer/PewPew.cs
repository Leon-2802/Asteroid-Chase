using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    [SerializeField] private WarshipMovement mothershipMovement = null;
    [SerializeField] private MeteorPooler meteorPooler = null;
    [SerializeField] private string laserPrefab = null;
    [SerializeField] private Transform[] spawns = null;
    [SerializeField] public float shootInt = 0;
    protected float currentShootInt;
    protected bool canShoot = false;

    private void OnEnable() 
    {
        currentShootInt = shootInt;
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot && mothershipMovement.arrived)
        {
            currentShootInt = shootInt;
            Shoot();
        }
        else 
        {
            currentShootInt -= Time.deltaTime;
            if(currentShootInt <= 0) {
                canShoot = true;
            }
        }
    }

    private void Shoot() 
    {
        canShoot = false;
        foreach(Transform spawn in spawns)
        {
            meteorPooler.SpawnProjectileFromPool(laserPrefab, 
            spawn.position, spawn.rotation);
        }

    }
}
