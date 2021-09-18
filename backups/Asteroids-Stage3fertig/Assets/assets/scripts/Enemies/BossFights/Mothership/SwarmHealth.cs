using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmHealth : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private string explosion = "";
    [SerializeField] private int points = 0;

    void Update()
    {
        if(transform.position.y >= 14.4f || transform.position.y <= -12f || transform.position.x >= 19.4f || transform.position.x <= -23f)
            Die();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("smolTarget") || other.CompareTag("enemy")) {
            Die();
        }
        if(other.CompareTag("laser")) {
            gameManager.GivePoints(points);
            Die();
        }
    }

    void Die()
    {
        enemyPooler.SpawnEnemiesFromPool(explosion, mainScript.enemyPos.position, mainScript.enemyPos.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        mainScript.gameObject.SetActive(false);
    }
}
