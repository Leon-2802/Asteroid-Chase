using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongY : MonoBehaviour
{
    [SerializeField] private float stop = 0f;
    [SerializeField] private float speed = 0f;

    void Update()
    {
        if(transform.position.y > stop) 
        {
            Vector3 newPos = transform.position;
            newPos -= transform.up * speed * Time.deltaTime;
            transform.position = newPos;
        }
    }
}
