using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrikadeHealth : MonoBehaviour
{
    [SerializeField] private MeteorPooler meteorPooler = null;
    [SerializeField] private string explosion = "";
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private int laserDamage = 0;
    [SerializeField] private int missileDamage = 0;
    private int currenthealth = 0;
    private int spriteCounter;

    void OnEnable() 
    {
        spriteRenderer.sprite = sprites[0];
        spriteCounter = 1;
        currenthealth = maxHealth;
    }

    void Update()
    {
        if(currenthealth <= 0 && spriteCounter < 6)
            ResetHealth();
        if(spriteCounter >= 6 && currenthealth <= 0) 
            Die();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemyLaser")) {
            currenthealth -= laserDamage;
        }
        else if(other.CompareTag("missile")) {
            currenthealth -= missileDamage;
        }
    }

    void ResetHealth()
    {
        spriteRenderer.sprite = sprites[spriteCounter];
        currenthealth = maxHealth;
        spriteCounter++;
    }
    void Die() 
    {
        meteorPooler.SpawnProjectileFromPool(explosion, transform.position, transform.rotation);
        meteorPooler.ObjectDestroyed(explosion);
        this.gameObject.SetActive(false);
    }
}
