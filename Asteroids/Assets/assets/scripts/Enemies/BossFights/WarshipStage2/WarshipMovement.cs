using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarshipMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private ParticleSystem engine1 = null;
    [SerializeField] private ParticleSystem engine2 = null;
    [SerializeField] private ParticleSystem engine3 = null;

    void Update()
    {
        if(transform.position.x < 9) {
            Vector3 newPosition = transform.position;
            newPosition += transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }
        else {
            engine1.startLifetime = 2;
            engine2.startLifetime = 2;
            engine3.startLifetime = 2;
        }
    }
}
