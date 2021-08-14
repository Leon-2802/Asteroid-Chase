using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarshipManager : MonoBehaviour
{
    [SerializeField] private BossManger bossManger = null;
    [SerializeField] private GameObject shipColliders = null;
    [SerializeField] private int maxHealth = 1000;
    [SerializeField] private int healthAfterWeaponsDestroyed = 500;
    [SerializeField] private healthbar healthbarScr = null;
    [SerializeField] private Shockwave shockwave = null;
    private int currentHealth;
    private float countdown = 3f;
    void Start()
    {
        currentHealth = maxHealth;
        healthbarScr.SetMaxHealth(currentHealth);
    }

    void Update() 
    {
        if(currentHealth <= 0) {
            shockwave.enabled = false;
            shipColliders.SetActive(false);
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
