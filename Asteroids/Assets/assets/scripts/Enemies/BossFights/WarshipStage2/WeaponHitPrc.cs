using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitPrc : EnemyHitPrc
{
    [SerializeField] private WarshipManager warshipManager = null;
    [SerializeField] private int damageToWarship = 0;

    protected override void Update()
    {
        if(currentHealth <= 0)
            Die();
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("laser")) {
            currentHealth -= 10;
            mainScript.animator.SetTrigger("Hit");
        }
        if(other.CompareTag("seismic"))
            currentHealth -= 60;
    }

    protected override void Die()
    {
        gameManager.GivePoints(mainScript.points);
        enemyPooler.SpawnEnemiesFromPool(explosion, mainScript.enemyPos.position, mainScript.enemyPos.rotation);
        enemyPooler.ObjectDestroyed(explosion);
        warshipManager.TakeDamage(damageToWarship);
        mainScript.gameObject.SetActive(false);
    }
}
