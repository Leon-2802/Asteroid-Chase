﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject lenkrakete = null;
    [SerializeField] private FollowTarget lenkraketeScript = null;
    [SerializeField] private LenkraketeManager lenkraketeManager = null;
    private bool enemySelected = false;

    private void OnEnable() 
    {
        enemySelected = false;
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began 
        && lenkraketeManager.missileCounter > 0 && enemySelected == false) 
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit.collider != null && hit.collider.transform.tag == "enemy") 
            {
                Animator targetAnim = hit.collider.transform.GetComponentInChildren<Animator>();
                if(targetAnim != null && targetAnim.GetBool("Selected") == false)
                {
                    enemySelected = true;
                    targetAnim.SetBool("Selected", true);
                    lenkraketeScript.target = hit.collider.transform;
                    lenkrakete.SetActive(true);
                }
            }
        }
    }
}
