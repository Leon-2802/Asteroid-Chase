using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spaceShipHitPrc : MonoBehaviour
{
    [SerializeField] private Animator shipAnim = null;
    [SerializeField] private healthbar healthbar = null;
    [SerializeField] private Image[] lives = null;
    [SerializeField] private Sprite greyHeart = null;
    [SerializeField] private int damageAsteroid = 20;
    [SerializeField] private int damageSmallAsteroidLaser = 10;
    [SerializeField] private int damageMissile = 80;
    private int lifeCount = 2;
    [SerializeField] private int maxHealth = 60;
    [SerializeField] private int currentHealth = 0;
    private bool hit = false;
    private float pause = 1.5f;
    private void Start() {
        healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    private void Update() 
    {
        if(currentHealth <= 0) {
            currentHealth = maxHealth;
            lives[lifeCount].sprite = greyHeart;
            lifeCount--;
            if(lifeCount <= -1) {
                SceneManager.LoadScene("main");
                return;
            }
            healthbar.SetMaxHealth(maxHealth);
        }
        
        if(hit == true) {
            pause -= Time.deltaTime;
            if(pause <= 0) {
                currentHealth -= damageSmallAsteroidLaser;
                healthbar.SetHealth(currentHealth);
                pause = 1.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("target") && hit == false) {
            hit = true;
            shipAnim.SetTrigger("Hit");
            currentHealth -= damageAsteroid;
            healthbar.SetHealth(currentHealth);
        }
        else if(other.CompareTag("smolTarget") && hit == false || other.CompareTag("enemyLaser") && hit == false) {
            hit = true;
            shipAnim.SetTrigger("Hit");
            currentHealth -= damageSmallAsteroidLaser;
            healthbar.SetHealth(currentHealth);
        }
        else if(other.CompareTag("missile")) {
            shipAnim.SetTrigger("Hit");
            currentHealth -= damageMissile;
            healthbar.SetHealth(currentHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("target") || other.CompareTag("smolTarget") || other.CompareTag("enemyLaser") 
        || other.CompareTag("missile")) {
            hit = false;
            shipAnim.SetTrigger("NoHit");
        }
    }
}
