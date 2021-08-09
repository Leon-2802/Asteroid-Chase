using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealthSmall : meteorHealth
{
    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("laser") || other.CompareTag("enemyLaser")) 
            currentHealth -= 10;
    
        if(other.CompareTag("seismic") || other.CompareTag("missile")) 
            currentHealth = 0;
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
        meteorPooler.ObjectDestroyed(objectTag);
        GameManager.instance.GivePoints(points);
        this.gameObject.SetActive(false);
    }
}
