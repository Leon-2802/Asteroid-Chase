using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretShooting : MonoBehaviour
{
    public PowerUpManager powerUpManager;
    public MeteorPooler meteorPooler;
    [SerializeField] public Transform target = null;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private float shootInt = 0f;
    [SerializeField] private string laser = "";
    [SerializeField] private Transform firePointL = null;
    [SerializeField] private Transform firePointR = null;
    private float currentShootInt;
    private bool canShoot = false;

    void OnEnable()
    {
        SelectTarget();
        currentShootInt = shootInt;
    }

    void Update()
    {
        if(target.gameObject.activeInHierarchy == false)
            SelectTarget();
        else {
            RotateToTarget();
            if(canShoot == true)
                Shoot();
        }
        if(canShoot == false) {
            currentShootInt -= Time.deltaTime;
            if(currentShootInt <= 0) {
                canShoot = true;
                currentShootInt = shootInt;
            }
        }
    }

    void RotateToTarget()
    {
        Vector2 lookdir = target.position - transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    void Shoot()
    {
        meteorPooler.SpawnProjectileFromPool(laser, firePointL.position, firePointL.rotation);
        meteorPooler.SpawnProjectileFromPool(laser, firePointR.position, firePointR.rotation);
        canShoot = false;
    }

    void SelectTarget()
    {
        if(powerUpManager == null)
            return;
        System.Random rnd = new System.Random();
        int random = Random.Range(0, powerUpManager.targets.Count - 1);
        if(random >= powerUpManager.targets.Count)
            SelectTarget();
        target = powerUpManager.targets[random];
    }
}
