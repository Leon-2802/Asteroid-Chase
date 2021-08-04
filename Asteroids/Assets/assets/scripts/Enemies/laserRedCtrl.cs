﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserRedCtrl : laserCtrl
{
    void Update()
    {
        if(noHit == true) {
            Vector3 newPosition = transform.position;
            newPosition += transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        if(transform.position.y >= 14.4f || transform.position.y <= -12f || transform.position.x >= 19.4f || transform.position.x <= -23f) {
            meteorPooler.ObjectDestroyed(objectTag);
            this.gameObject.SetActive(false);
        }

        currentLifetime -= Time.deltaTime;

        if(currentLifetime <= 0f) {
            meteorPooler.ObjectDestroyed(objectTag);
            this.gameObject.SetActive(false);
        }
    }
}
