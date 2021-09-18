using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarshipManager : MonoBehaviour
{
    [SerializeField] protected BossManger bossManger = null;
    [SerializeField] protected GameObject shipColliders = null;
    [SerializeField] protected SpriteRenderer sprite = null;
    [SerializeField] protected GameObject flames = null;
    [SerializeField] protected GameObject explosion = null;
    [SerializeField] protected int maxHealth = 1000;
    [SerializeField] public int healthAfterWeaponsDestroyed = 500;
    [SerializeField] protected healthbar healthbarScr = null;
    [SerializeField] private Shockwave shockwave = null;
    public int currentHealth;
    protected float countdown = 3f;
    void Start()
    {
        currentHealth = maxHealth;
        healthbarScr.SetMaxHealth(currentHealth);
    }

    protected virtual void Update() 
    {
        if(currentHealth <= 0) {
            shockwave.enabled = false;
            shipColliders.SetActive(false);
            flames.SetActive(false);
            sprite.enabled = false;
            explosion.SetActive(true);
            countdown -= Time.deltaTime;
            if(countdown <= 0) {
                bossManger.EndBossFight2();
            }
        }

        if(currentHealth <= healthAfterWeaponsDestroyed) {
            shipColliders.SetActive(true);
            shockwave.enabled = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbarScr.SetHealth(currentHealth);
    }
}
