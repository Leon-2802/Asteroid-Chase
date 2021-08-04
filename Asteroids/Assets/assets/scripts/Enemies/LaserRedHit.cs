using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRedHit : MonoBehaviour
{
    public laserRedCtrl laserCtrl;
    [SerializeField] private Animator animator = null;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) {
            laserCtrl.noHit = false;
            animator.SetTrigger("explode");
            laserCtrl.currentLifetime = 0.5f;
        }
        if(other.CompareTag("target")) {
            if(other.gameObject.transform.childCount > 0 && other.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                return;
            else {
                laserCtrl.noHit = false;
                animator.SetTrigger("explode");
                laserCtrl.currentLifetime = 0.5f;
            }
        }
    }
}
