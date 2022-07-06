using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmShip : Enemy
{
    [SerializeField] private GameObject movement = null;
    [SerializeField] private SwarmRotation rotation = null;
    [SerializeField] private float moveCountdown = 0f;
    private float currentCountdown = 0f;

    void OnEnable()
    {
        currentCountdown = moveCountdown;
        rotation.enabled = true;
    }
    void Update()
    {
        currentCountdown -= Time.deltaTime;
        if(currentCountdown <= 0) {
            enemyRb.velocity = new Vector2(0, 0);
            movement.SetActive(true);
        } 
    }

    void OnDisable()
    {
        movement.SetActive(false); 
    }
}
