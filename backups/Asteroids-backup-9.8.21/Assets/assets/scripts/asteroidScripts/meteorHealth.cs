using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorHealth : MonoBehaviour
{
    [SerializeField] protected string objectTag = null;
    protected MeteorPooler meteorPooler;
    [SerializeField] protected int maxHealth = 30;
    private bool healthSet = false;
    [SerializeField] protected int currentHealth = 0;
    public OnDestroyTurret onDestroyTurret;
    [SerializeField] protected string diePrefab = null;
    [SerializeField] protected string explosion = null;
    [SerializeField] protected int dieObjectCount = 4;
    [SerializeField] protected int points = 1;

    public void OnEnable()
    {
        meteorPooler = MeteorPooler.Instance;
        currentHealth = maxHealth;
    }

    protected void Update()
    {
        if(currentHealth <= 0) {
            Die();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("laser")) {
            if(onDestroyTurret.gameObject.activeInHierarchy && healthSet == false)
                SetMaxHealth();
            currentHealth -= 10;
        }
        if(other.CompareTag("enemyLaser")) {
            if(onDestroyTurret.gameObject.activeInHierarchy)
                return;
            currentHealth -= 10;
        }
    
        if(other.CompareTag("seismic") || other.CompareTag("missile")) 
            currentHealth = 0;
    }

    void SetMaxHealth() 
    {
        currentHealth = maxHealth + onDestroyTurret.health;
        healthSet = true;
    }

    protected virtual void Die() 
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
        if(onDestroyTurret.gameObject.activeInHierarchy)
            GameManager.instance.GivePoints(onDestroyTurret.points);
        this.gameObject.SetActive(false);
    }
}
