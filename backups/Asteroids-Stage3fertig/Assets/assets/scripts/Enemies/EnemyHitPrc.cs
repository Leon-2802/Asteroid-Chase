using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPrc : MonoBehaviour
{
    [SerializeField] protected Enemy mainScript = null;
    [SerializeField] protected GameManager gameManager = null;
    [SerializeField] protected EnemyPooler enemyPooler = null;
    [SerializeField] protected int maxHealth = 0;
    [SerializeField] protected int currentHealth = 0;
    [SerializeField] protected string explosion = null;

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
    protected virtual void Update()
    {
        if(currentHealth <= 0)
            Die();
        if(gameManager.currentStage == GameManager.Stages.STAGE_2 && mainScript.objectTag == "MissileLauncher") 
            Delete();
        if(gameManager.bossFight[1] == true || gameManager.bossFight[2] == true)
            Delete();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        string tag = other.tag;
        switch(tag)
        {
            case "laser":
                currentHealth -= 10;
                mainScript.animator.SetTrigger("Hit");
                break;
            case "seismic":
                currentHealth = 0;
                break;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("laser")) 
            mainScript.animator.SetTrigger("NoHit");
    }

    protected virtual void Die()
    {
        gameManager.GivePoints(mainScript.points);
        if(mainScript.objectTag == "MissileLauncher" && gameManager.currentStage == GameManager.Stages.STAGE_1)
            gameManager.deadBossEnemies[0]++;
        enemyPooler.ObjectDestroyed(mainScript.objectTag);
        enemyPooler.SpawnEnemiesFromPool(explosion, mainScript.enemyPos.position, mainScript.enemyPos.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        mainScript.gameObject.SetActive(false);
    }
    protected void Delete()
    {
        enemyPooler.ObjectDestroyed(mainScript.objectTag);
        enemyPooler.SpawnEnemiesFromPool(explosion, mainScript.enemyPos.position, mainScript.enemyPos.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        mainScript.gameObject.SetActive(false);
    }
}
