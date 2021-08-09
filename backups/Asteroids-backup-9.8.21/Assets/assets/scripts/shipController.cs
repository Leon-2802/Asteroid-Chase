using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private FixedJoystick joystickL = null;
    [SerializeField] private FixedJoystick joystickR = null;

    [SerializeField] private Camera cam = null;

    private Vector2 movement;
    private Vector2 mousePos;
    void Start()
    {
        
    }

    void Update()
    {
        // float moveX = Input.GetAxisRaw("Horizontal");
        // float moveY = Input.GetAxisRaw("Vertical");
        float moveX = joystickL.Horizontal;
        float moveY = joystickL.Vertical;
        movement = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(transform.position.x < -18.10f) {
            Vector3 newPos = transform.position;
            newPos.x = 17.78f;
            transform.position = newPos;
        }
        else if(transform.position.x > 18.1f) {
            Vector3 newPos = transform.position;
            newPos.x = -18f;
            transform.position = newPos;
        }
        else if(transform.position.y < -10.5f) {
            Vector3 newPos = transform.position;
            newPos.y = 10.47f;
            transform.position = newPos;
        }
        else if(transform.position.y > 10.5f) {
            Vector3 newPos = transform.position;
            newPos.y = -10.47f;
            transform.position = newPos;
        }

    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

        // Vector2 lookDirec = mousePos - rb.position;
        // float angle = Mathf.Atan2(lookDirec.y, lookDirec.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;

        float rotX = joystickR.Horizontal;
        float rotY = joystickR.Vertical;
        Vector2 rotation = new Vector2(rotX, rotY).normalized;
        float angle2 = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle2;
    }
}
