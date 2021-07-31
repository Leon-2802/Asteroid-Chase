using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeismicChargeCtrl : laserCtrl
{
    void Update()
    {
        if(noHit == true) {
            Vector3 newPosition = transform.position;
            newPosition -= transform.up * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        lifetime -= Time.deltaTime;

        if(lifetime <= 0f) {
            Destroy(this.gameObject);
        }
    }
}
