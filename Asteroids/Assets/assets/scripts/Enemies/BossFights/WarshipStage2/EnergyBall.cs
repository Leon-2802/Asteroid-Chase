using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField] private float lifetime = 0f;
    private float currentLifetime;

    void OnEnable()
    {
        currentLifetime = lifetime;
    }
    void Update()
    {
        currentLifetime -= Time.deltaTime;
        if(currentLifetime <= 0)
            this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) {
            this.gameObject.SetActive(false);
        }
    }
}
