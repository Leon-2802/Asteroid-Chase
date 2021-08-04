using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPrc : MonoBehaviour
{
    public Enemy mainScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyPooler enemyPooler;
    public int maxHealth;
    [SerializeField] private int currentHealth;

    void Start() 
    {
        gameManager = GameManager.instance;
        enemyPooler = EnemyPooler.instance;
        currentHealth = maxHealth;
    }
    void OnDisable() 
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if(currentHealth <= 0)
            Die();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("laser")) 
            currentHealth -= 10;
        if(other.collider.CompareTag("seismic"))
            currentHealth = 0;
    }

    void Die()
    {
        gameManager.GivePoints(mainScript.points);
        enemyPooler.ObjectDestroyed(mainScript.objectTag);
        mainScript.gameObject.SetActive(false);
    }
}
