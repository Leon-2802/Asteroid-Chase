using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHitPrc : MonoBehaviour
{
    [SerializeField] private WarshipManager warshipManager = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private int damage = 0;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("laser")) {
            warshipManager.TakeDamage(damage);
            animator.SetTrigger("Hit");
        }
    }
}
