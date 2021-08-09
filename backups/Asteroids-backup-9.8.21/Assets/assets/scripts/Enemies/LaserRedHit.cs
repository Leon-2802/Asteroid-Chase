using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRedHit : laserHit
{
    [SerializeField] private laserRedCtrl laserRedCtrl = null;
    protected override void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")) {
            laserRedCtrl.noHit = false;
            animator.SetTrigger("explode");
            laserRedCtrl.currentLifetime = 0.5f;
        }
        if(other.CompareTag("target")) {
            if(other.gameObject.transform.childCount > 0 && other.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                return;
            else {
                laserRedCtrl.noHit = false;
                animator.SetTrigger("explode");
                laserRedCtrl.currentLifetime = 0.5f;
            }
        }
    }
}
