﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserHit : MonoBehaviour
{
    [SerializeField] private laserCtrl laserCtrl = null;
    [SerializeField] protected Animator animator = null;
    [SerializeField] protected BoxCollider2D triggerCollider = null;

    protected void Start() 
    {
        triggerCollider.enabled = true;
    }
    protected void OnEnable() 
    {
        triggerCollider.enabled = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("target") || other.CompareTag("enemy") || other.CompareTag("smolTarget") || other.CompareTag("missile")) {
            laserCtrl.noHit = false;
            animator.SetTrigger("explode");
            DisableColliders();
            laserCtrl.currentLifetime = 0.3f;
        }
    }
    protected void DisableColliders()
    {
        triggerCollider.enabled = false;
    }
}
