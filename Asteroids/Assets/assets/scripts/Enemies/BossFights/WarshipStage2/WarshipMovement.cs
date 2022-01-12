using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarshipMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private float stopPoint = 13f;
    [SerializeField] private ParticleSystem[] engines = null;
    public bool arrived = false;
    
    void Update()
    {
        if(transform.position.x < stopPoint) {
            Vector3 newPosition = transform.position;
            newPosition += transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }
        else {
            arrived = true;
            foreach(ParticleSystem ps in engines) {
                ps.startLifetime = 2;
            }
        }
    }
}
