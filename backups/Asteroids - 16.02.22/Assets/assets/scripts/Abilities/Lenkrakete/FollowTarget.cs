using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject graphics = null;
    [SerializeField] public Transform target = null;
    [SerializeField] private Transform startPos = null;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float timeout = 1f;
    private float currentTimeout = 0f;
    Vector3 move;

    void OnEnable() 
    {
        transform.position = startPos.position;
        currentTimeout = timeout;
    }


    void Update()
    {
        if(target != null)
        {
            currentTimeout -= Time.deltaTime;
            if(currentTimeout < 0) 
            {
                graphics.SetActive(true);
                Vector2 lookdir = target.position - transform.position;
                float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;

                move = transform.position;
                move += transform.up * speed * Time.deltaTime;
                transform.position = move;
            }
        }
    }

    private void OnDisable() {
        graphics.SetActive(false);
    }
}
