using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] public Transform target = null;
    [SerializeField] private Transform startPos = null;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private float speed = 0f;
    Vector3 move;

    void OnEnable() 
    {
        transform.position = startPos.position;
    }


    void Update()
    {
        if(target != null)
        {
            Vector2 lookdir = target.position - transform.position;
            float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            move = transform.position;
            move += transform.up * speed * Time.deltaTime;
            transform.position = move;
        }
    }
}
