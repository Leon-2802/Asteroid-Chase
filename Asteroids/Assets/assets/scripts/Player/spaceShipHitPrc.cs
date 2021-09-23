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
    public bool hit = false;
    private int lifeCount = 2;
    [SerializeField] private int maxHealth = 60;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private shootCtrl shootCtrl = null;
    [SerializeField] private shipController shipController = null;
    [SerializeField] private SpaceInvadersCtrls spaceInvadersCtrls = null;
    [SerializeField] private float shockwaveCounter = 0f;
    private float currentShockwaveCounter;
    private bool shockwaveHit = false;
    [SerializeField] private float energyBallInt = 0f;
    private float currentEnergyBallInt;
    private bool energyBallHit;
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
        if(energyBallHit == true)
            EnergyBallHit();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "enemyLaser":
            case "smoltarget":
                if(hit == false) {
                    hit = true;
                    shipAnim.SetTrigger("Hit");
                    currentHealth -= damageSmallAsteroidLaser;
                    healthbar.SetHealth(currentHealth);
                }
                break;
            case "missile":
                shipAnim.SetTrigger("Hit");
                currentHealth -= damageMissile;
                healthbar.SetHealth(currentHealth);
                break;
            case "magnetic":
                meteorManager.magneticPull = true;
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
            case "energySI":
                currentEnergyBallInt = energyBallInt;
                shipAnim.SetTrigger("Hit");
                currentHealth -= damageEnergyBall;
                healthbar.SetHealth(currentHealth);
                shootCtrl.enabled = false;
                spaceInvadersCtrls.enabled = false;
                energyBallHit = true;
                break;
            case "target":
                if(hit == false) {
                    hit = true;
                    shipAnim.SetTrigger("Hit");
                    currentHealth -= damageAsteroid;
                    healthbar.SetHealth(currentHealth);
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("magnetic")) 
            meteorManager.magneticPull = false;
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
    private void EnergyBallHit()
    {
        currentEnergyBallInt -= Time.deltaTime;
        if(currentEnergyBallInt <= 0) {
            shipAnim.SetTrigger("NoHit");
            shootCtrl.enabled = true;
            spaceInvadersCtrls.enabled = true;
            energyBallHit = false;
        }
    }

    public void GiveHealth(int health)
    {
        currentHealth += health;
        if(currentHealth > maxHealth) 
            currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }
}
