using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private float xValue = 2f;
    private float yValue = 1f;
    Vector3 initialPos;

    void OnEnable()
    {
        initialPos = transform.position;

        if(initialPos.y > 0)
            yValue = UnityEngine.Random.Range(-2f, -0.7f);
        else
            yValue = UnityEngine.Random.Range(0.7f, 2f);

        if(initialPos.x > 0)
            xValue = UnityEngine.Random.Range(-2f, -0.7f);
        else
            xValue = UnityEngine.Random.Range(0.7f, 2f);
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(xValue, yValue) * speed * Time.deltaTime;
        transform.position = newPos;

        if(transform.position.y >= 12f || transform.position.y <= -12f || transform.position.x >= 19.5f || transform.position.x <= -19.5f) 
            Destroy();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            Destroy();
        }
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}
