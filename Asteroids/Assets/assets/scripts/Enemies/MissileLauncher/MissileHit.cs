using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHit : MonoBehaviour
{
    [SerializeField] private laserCtrl laserCtrl = null;
    [SerializeField] private BoxCollider2D boxCollider2D = null;

    private void OnEnable() {
        boxCollider2D.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") || other.CompareTag("target")) {
            DisableCollider();
            laserCtrl.currentLifetime = 0f;
        }
    }

    void DisableCollider()
    {
        boxCollider2D.enabled = false;
    }
}
