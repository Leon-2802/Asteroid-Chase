using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorHealth : MonoBehaviour
{
    [SerializeField] protected string objectTag = null;
    protected MeteorPooler meteorPooler;
    protected GameManager gameManager;
    [SerializeField] private Animator animator = null;
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
        gameManager = GameManager.instance;
        currentHealth = maxHealth;
    }

    protected void Update()
    {
        if(currentHealth <= 0) {
            Die();
        }
        if(gameManager.bossFight[1] == true) {
            Die();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("laser")) {
            if(onDestroyTurret.gameObject.activeInHierarchy && healthSet == false)
                SetMaxHealth();
            currentHealth -= 10;
            animator.SetTrigger("Hit");
        }
        if(other.CompareTag("enemyLaser")) {
            if(onDestroyTurret.gameObject.activeInHierarchy)
                return;
            currentHealth -= 10;
            animator.SetTrigger("Hit");
        }
    
        if(other.CompareTag("seismic") || other.CompareTag("missile")) 
            currentHealth = 0;
    }
    protected virtual void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("laser"))
            animator.SetTrigger("NoHit");
        if(other.CompareTag("enemyLaser")) 
            animator.SetTrigger("NoHit");
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
