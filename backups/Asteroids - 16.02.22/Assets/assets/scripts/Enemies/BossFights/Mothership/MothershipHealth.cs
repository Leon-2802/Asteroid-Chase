using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipHealth : MonoBehaviour
{
    [SerializeField] private MothershipManager mothershipManager = null;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private Animator animator = null;
    [SerializeField] private string animTrigger = "";
    [SerializeField] private GameObject smoke = null;
    [SerializeField] private GameObject[] weapons = null;
    [SerializeField] private int damageToMothership = 0;
    [SerializeField] private int points = 0;
    private int currentHealth = 0;
    private bool destroyed = false;

    void OnEnable()
    {
        currentHealth = maxHealth;
        smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0 && destroyed == false)
            Destroyed();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("laser")) {
            if(mothershipManager.currentHealth <= mothershipManager.healthAfterWeaponsDestroyed) {
                mothershipManager.TakeDamage(10);
                animator.SetTrigger("HurtAll");
                return;
            }
            if(currentHealth <= 0)
                return;
            
            currentHealth -= 10;
            animator.SetTrigger(animTrigger);
        }
    }

    void Destroyed()
    {
        destroyed = true;
        smoke.SetActive(true);
        mothershipManager.TakeDamage(damageToMothership);
        mothershipManager.gameManager.GivePoints(points);
        foreach(GameObject weapon in weapons) {
            weapon.SetActive(false);
        }
    }
}
