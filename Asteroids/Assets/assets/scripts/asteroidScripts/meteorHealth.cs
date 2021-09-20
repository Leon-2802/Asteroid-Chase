using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorHealth : MonoBehaviour
{
    [SerializeField] protected string objectTag = null;
    public MeteorPooler meteorPooler;
    public GameManager gameManager;
    [SerializeField] private Animator animator = null;
    [SerializeField] protected int maxHealth = 30;
    private bool healthSet = false;
    [SerializeField] protected int currentHealth = 0;
    public OnDestroyTurret onDestroyTurret;
    [SerializeField] protected string diePrefab = null;
    [SerializeField] protected string explosion = null;
    [SerializeField] protected int dieObjectCount = 4;
    [SerializeField] protected int points = 1;
    private bool delete = false;

    public void OnEnable()
    {
        currentHealth = maxHealth;
        delete = false;
    }

    protected void Update()
    {
        if(currentHealth <= 0) 
            Die();

        CheckForBossFight();
        if(delete == true) 
            Delete();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        string tag = other.tag;
        switch (tag)
        {
            case "laser":
                if(onDestroyTurret.gameObject.activeInHierarchy && healthSet == false)
                    SetMaxHealth();
                currentHealth -= 10;
                animator.SetTrigger("Hit");
                break;
            case "enemyLaser":
                if(onDestroyTurret.gameObject.activeInHierarchy)
                    return;
                currentHealth -= 10;
                animator.SetTrigger("Hit"); 
                break;
            case "seismic": 
            case "missile":
            case "shield":
                currentHealth = 0;
                break;
        }
    }

    void SetMaxHealth() 
    {
        currentHealth = maxHealth + onDestroyTurret.health;
        healthSet = true;
    }

    void CheckForBossFight()
    {
        for(int i = 1; i < gameManager.bossFight.Length; i++)
        {
            if(gameManager.bossFight[i] == true)
                delete = true;
        }
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
        meteorPooler.MeteorDestroyed(objectTag, this.gameObject);
        GameManager.instance.GivePoints(points);
        if(onDestroyTurret.gameObject.activeInHierarchy)
            GameManager.instance.GivePoints(onDestroyTurret.points);
        this.gameObject.SetActive(false);
    }
    protected void Delete()
    {
        meteorPooler.SpawnProjectileFromPool(explosion, transform.position, transform.rotation);
        meteorPooler.ObjectDestroyed(explosion);
        meteorPooler.MeteorDestroyed(objectTag, this.gameObject);
        this.gameObject.SetActive(false);
    }
}
