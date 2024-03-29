﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMovement : MonoBehaviour
{
    [SerializeField] public string objectTag = null;
    meteorManager meteorManager;
    [SerializeField] private float speed = 1f;
    public float xValue = 2f;
    public float yValue = 1f;
    Vector3 initialPos;

    private void Start() {
        meteorManager = meteorManager.instance;
    }
    public void OnEnable() 
    {
        initialPos = transform.position;
        
        if(initialPos.y > 0)
            yValue = UnityEngine.Random.Range(-2f, -0.7f);
        else
            yValue = UnityEngine.Random.Range(0.7f, 2f);

        if(initialPos.x > 0)
            xValue = UnityEngine.Random.Range(-2f, -0.7f);
        else
            xValue = UnityEngine.Random.Range(0.7f, 2f);
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(xValue, yValue) * speed * Time.deltaTime;
        transform.position = newPos;

        if(transform.position.y >= 14.4f || transform.position.y <= -12f || transform.position.x >= 19.4f || transform.position.x <= -23f) 
            relocate();
    }

    void relocate() 
    {
        if(meteorManager.bossPhase == true) {
            meteorManager.meteorRelocated(objectTag, this.gameObject);
            this.gameObject.SetActive(false);
            return;
        }
        
        if(objectTag == "big1" || objectTag == "big2" || objectTag == "big3" || objectTag == "magnetic")
            meteorManager.spawnMeteor();
        else 
            meteorManager.spawnChildMeteor(objectTag);
        
        meteorManager.meteorRelocated(objectTag, this.gameObject);
        this.gameObject.SetActive(false);
    }
}
