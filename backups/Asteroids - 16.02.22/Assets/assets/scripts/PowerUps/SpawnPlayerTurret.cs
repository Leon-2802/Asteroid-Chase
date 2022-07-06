using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerTurret : MonoBehaviour
{
    [SerializeField] private PowerUpPooler powerUpPooler = null;
    private bool hit;

    void OnEnable()
    {
        hit = false;
    }

    void Start()
    {
       powerUpPooler = PowerUpPooler.instance; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && hit == false) {
            hit = true;
            powerUpPooler.SpawnTurretFromPool("playerTurret", transform.position, transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
