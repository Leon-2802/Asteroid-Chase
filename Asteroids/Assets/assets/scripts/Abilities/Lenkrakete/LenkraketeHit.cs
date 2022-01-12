using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenkraketeHit : MonoBehaviour
{
    [SerializeField] private GameObject parent = null;
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private string explosion = null;
    [SerializeField] private float lifeTime = 2f;
    private float currentLifetime = 0;

    private void OnEnable() 
    {
        currentLifetime = lifeTime;
    }
    private void Update() 
    {
        currentLifetime -= Time.deltaTime;
        if(currentLifetime < 0)
        {
            enemyPooler.SpawnEnemiesFromPool(explosion, transform.position, transform.rotation);
            enemyPooler.ObjectDestroyed(explosion);
            parent.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("enemy"))
        {
            enemyPooler.SpawnEnemiesFromPool(explosion, transform.position, transform.rotation);
            enemyPooler.ObjectDestroyed(explosion);
            parent.SetActive(false);
        }
    }
}
