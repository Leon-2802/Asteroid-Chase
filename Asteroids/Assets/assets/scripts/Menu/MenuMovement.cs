using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0f;

    void OnEnable() 
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(transform.position.x > 30.2f) {
            Vector3 newPos = transform.position;
            newPos.x = -31.6f;
            transform.position = newPos;
        }
        else {
            Vector3 newPosition = transform.position;
            newPosition += transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
