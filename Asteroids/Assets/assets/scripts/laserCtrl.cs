using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCtrl : MonoBehaviour
{
    [SerializeField] private float speed = 55f;
    public float lifetime = 5f;
    public bool noHit = true;
    
    void Update()
    {
        if(noHit == true) {
            Vector3 newPosition = transform.position;
            newPosition += transform.up * speed * Time.deltaTime;
            transform.position = newPosition;
        }

        lifetime -= Time.deltaTime;

        if(lifetime <= 0f) {
            Destroy(this.gameObject);
        }
    }
}
