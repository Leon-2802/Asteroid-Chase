using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPrc : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private string explosion = null;

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
        if(gameManager.currentStage == GameManager.Stages.STAGE_2 && mainScript.objectTag == "MissileLauncher") //Kill remaining Missile Launchers after BossFight[0]
            Die();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("laser")) {
            currentHealth -= 10;
            mainScript.animator.SetTrigger("Hit");
        }
        if(other.CompareTag("seismic"))
            currentHealth = 0;
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("laser")) 
            mainScript.animator.SetTrigger("NoHit");
    }

    void Die()
    {
        gameManager.GivePoints(mainScript.points);
        if(mainScript.objectTag == "MissileLauncher" && gameManager.currentStage == GameManager.Stages.STAGE_1)
            gameManager.deadBossEnemies[0]++;
        enemyPooler.ObjectDestroyed(mainScript.objectTag);
        enemyPooler.SpawnEnemiesFromPool(explosion, mainScript.enemyPos.position, mainScript.enemyPos.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        mainScript.gameObject.SetActive(false);
    }
}
