using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spaceShipHitPrc : MonoBehaviour
{
    [SerializeField] private healthbar healthbar = null;
    [SerializeField] private Image[] lives = null;
    [SerializeField] private Sprite greyHeart = null;
    private int lifeCount = 2;
    [SerializeField] private int maxHealth = 60;
    private int currentHealth = 0;
    private bool hit = false;
    private float pause = 0.8f;
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
                SceneManager.LoadScene("SampleScene");
                return;
            }
            healthbar.SetMaxHealth(maxHealth);
        }
        else if(hit == true) {
            pause -= Time.deltaTime;
            if(pause <= 0) {
                hit = false;
                pause = 0.8f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("target") && hit == false) {
            hit = true;
            currentHealth -= 20;
            healthbar.SetHealth(currentHealth);
        }
        else if(other.CompareTag("smolTarget") && hit == false) {
            hit = true;
            currentHealth -= 10;
            healthbar.SetHealth(currentHealth);
        }
    }
}
