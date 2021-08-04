using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealthSmall : meteorHealth
{
    protected override void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("laser")) 
            currentHealth -= 10;
    
        if(other.collider.CompareTag("seismic")) 
            currentHealth = 0;
    }
    protected override void Die() 
    {
        if(diePrefab != null) {
            for(int i = 0; i < dieObjectCount; i++) {
                meteorPooler.spawnMeteorsFromPool(diePrefab, transform.position, transform.rotation);
            }
        }
        meteorPooler.ObjectDestroyed(objectTag);
        GameManager.instance.AsteroidDied(points);
        this.gameObject.SetActive(false);
    }
}
