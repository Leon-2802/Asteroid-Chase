using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealthSmall : meteorHealth
{
    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        string tag = other.tag;
        switch(tag) 
        {
            case "laser":
            case "enemyLaser":
                currentHealth -= 10;
                break;
            case "seismic":
            case "missile":
                currentHealth = 0;
                break;
        }
    }

    protected override void Die() 
    {
        meteorPooler.SpawnProjectileFromPool(explosion, transform.position, transform.rotation);
        meteorPooler.ObjectDestroyed(explosion);
        if(diePrefab != null) {
            for(int i = 0; i < dieObjectCount; i++) {
                meteorPooler.spawnMeteorsFromPool(diePrefab, transform.position, transform.rotation);
            }
        }
        meteorPooler.MeteorDestroyed(objectTag, this.gameObject);
        GameManager.instance.GivePoints(points);
        this.gameObject.SetActive(false);
    }
}
