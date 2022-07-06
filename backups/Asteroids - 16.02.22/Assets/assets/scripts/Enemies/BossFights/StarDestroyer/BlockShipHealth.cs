using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShipHealth : MonoBehaviour
{
    [SerializeField] private int health = 0;
    [SerializeField] private int laserDamage = 0;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private string explosion = "";
    [SerializeField] private int points = 0;
    private int currentHealth = 0;
    
    private void OnEnable() 
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("laser"))
        {
            currentHealth -= laserDamage;
        }
    }
    private void Die()
    {
        gameManager.GivePoints(points);
        enemyPooler.SpawnEnemiesFromPool(explosion, transform.position, transform.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        this.transform.gameObject.SetActive(false);
    }
}
