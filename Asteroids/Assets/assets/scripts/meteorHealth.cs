using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorHealth : MonoBehaviour
{
     MeteorPooler meteorPooler;
    [SerializeField] private int maxHealth = 30;
    private int currentHealth = 0;
    [SerializeField] private string diePrefab = null;
    [SerializeField] private int dieObjectCount = 4;
    [SerializeField] private int points = 0;

    public void OnEnable()
    {
        meteorPooler = MeteorPooler.Instance;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("laser")) 
            currentHealth -= 10;
    
        if(other.collider.CompareTag("seismic")) 
            currentHealth = 0;
    }

    void Die() 
    {
        if(diePrefab != null) {
            for(int i = 0; i < dieObjectCount; i++) {
                meteorPooler.spawnMeteorsFromPool(diePrefab, transform.position, transform.rotation);
            }
        }
        GameManager.instance.AsteroidDied(points);
        this.gameObject.SetActive(false);
    }
}
