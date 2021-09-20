using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretHitPrc : MonoBehaviour
{
    [SerializeField] public EnemyPooler enemyPooler = null;
    [SerializeField] public GameManager gameManager = null;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private float maxLifetime = 60f;
    [SerializeField] private string explosion = "";
    private int currentHealth;
    private float currentLifetime;
    private bool delete = false;
    
    void OnEnable()
    {
        currentHealth = maxHealth;
        currentLifetime = maxLifetime;
        delete = false;
    }

    private void Update() 
    {
        if(currentHealth <= 0)
            Die();

        currentLifetime -= Time.deltaTime;
        if(currentLifetime <= 0)
            Die();

        CheckForBossFight();
        if(delete == true)
            Die();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "target":
            case "smolTarget":
            case "enemy":
            case "missile":
            case "energy":
            case "energySI":
                Die();
                break;
            case "enemyLaser":
                currentHealth -= 10;
                break;
        }
    }

    void CheckForBossFight()
    {
        for(int i = 1; i < gameManager.bossFight.Length; i++)
        {
            if(gameManager.bossFight[i] == true)
                delete = true;
        }
    }

    void Die() 
    {
        enemyPooler.SpawnEnemiesFromPool(explosion, transform.position, transform.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        this.gameObject.SetActive(false);
    }
}
