using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spaceShipHitPrc : MonoBehaviour
{
    [SerializeField] private meteorManager meteorManager = null;
    [SerializeField] private Animator shipAnim = null;
    [SerializeField] private healthbar healthbar = null;
    [SerializeField] private Image[] lives = null;
    [SerializeField] private Sprite greyHeart = null;
    [SerializeField] private int damageAsteroid = 20;
    [SerializeField] private int damageSmallAsteroidLaser = 10;
    [SerializeField] private int damageMissile = 80;
    [SerializeField] private int damageEnergyBall = 60;
    private int lifeCount = 2;
    [SerializeField] private int maxHealth = 60;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private shootCtrl shootCtrl = null;
    [SerializeField] private shipController shipController = null;
    [SerializeField] private float shockwaveCounter = 0f;
    private float currentShockwaveCounter;
    private bool shockwaveHit = false;
    private bool hit = false;
    private float pause = 1.5f;
    private void Start() {
        healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        currentShockwaveCounter = shockwaveCounter;
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

        if(shockwaveHit == true) {
            ShockwaveHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "target":
                if(hit == false) {
                    hit = true;
                    shipAnim.SetTrigger("Hit");
                    currentHealth -= damageAsteroid;
                    healthbar.SetHealth(currentHealth);
                }
                break;
            case "smoltarget":
            case "enemyLaser":
                if(hit == false) {
                    hit = true;
                    shipAnim.SetTrigger("Hit");
                    currentHealth -= damageSmallAsteroidLaser;
                    healthbar.SetHealth(currentHealth);
                }
                break;
            case "magnetic":
                meteorManager.magneticPull = true;
                break;
            case "missile":
                shipAnim.SetTrigger("Hit");
                currentHealth -= damageMissile;
                healthbar.SetHealth(currentHealth);
                break;
            case "energy":
                currentShockwaveCounter = shockwaveCounter;
                shipAnim.SetTrigger("Hit");
                currentHealth -= damageEnergyBall;
                healthbar.SetHealth(currentHealth);
                shootCtrl.enabled = false;
                shipController.enabled = false;
                shockwaveHit = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        string tag = other.gameObject.tag;
        switch (tag)
        {
            case "target":
            case "smolTarget":
            case "enemyLaser":
            case "missile":
                hit = false;
                shipAnim.SetTrigger("NoHit");
                break;
            case "magnetic":
                meteorManager.magneticPull = false;
                break;
        }
    }

    private void ShockwaveHit()
    {
        currentShockwaveCounter -= Time.deltaTime;
        if(currentShockwaveCounter <= 0f) {
            currentHealth -= 20;
            healthbar.SetHealth(currentHealth);
            shipAnim.SetTrigger("NoHit");
            shootCtrl.enabled = true;
            shipController.enabled = true;
            shockwaveHit = false;
        }
    }
}
