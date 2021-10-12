using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenkraketeHit : MonoBehaviour
{
    [SerializeField] private GameObject parent = null;
    [SerializeField] private TouchManager touchManager = null;
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private string explosion = null;

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
