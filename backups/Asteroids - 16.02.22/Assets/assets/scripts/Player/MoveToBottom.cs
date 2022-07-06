using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBottom : MonoBehaviour
{
    [SerializeField] private GameObject spaceship = null;
    [SerializeField] private Rigidbody2D playerRb = null;
    [SerializeField] private float speed = 0f;

    void OnEnable()
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.angularVelocity = 0f;
        playerRb.rotation = 0f;
    }

    void Update()
    {
        if(spaceship.transform.position.y > -6.35f)
        {
            Vector3 newPos = spaceship.transform.position;
            newPos -= transform.up * speed * Time.deltaTime;
            spaceship.transform.position = newPos;
        }
    }
}
