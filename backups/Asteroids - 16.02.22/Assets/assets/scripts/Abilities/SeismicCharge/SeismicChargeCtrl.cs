using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeismicChargeCtrl : laserCtrl
{
    protected override void Update()
    {
        if(noHit == true) {
            Vector3 newPosition = transform.position;
            newPosition -= transform.up * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        currentLifetime -= Time.deltaTime;

        if(currentLifetime <= 0f) {
            meteorPooler.ObjectDestroyed(objectTag);
            this.gameObject.SetActive(false);
        }
    }
}
