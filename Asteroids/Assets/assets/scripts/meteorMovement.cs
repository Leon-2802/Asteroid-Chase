using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public float xValue = 2f;
    public float yValue = 1f;
    [SerializeField] private float[] xValues = null;
    [SerializeField] private float[] yValues = null;
    Vector3 initialPos;

    public void OnEnable() {
        initialPos = transform.position;
        xValue = Random.Range(0, xValues.Length);
        yValue = Random.Range(0, yValues.Length);
    }
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos += new Vector3(xValue, yValue) * speed * Time.deltaTime;
        transform.position = newPos;

        if(transform.position.y >= 11.6f || transform.position.y <= -10.6f || transform.position.x >= 19.6f || transform.position.x <= -19.3f) {
            relocate();
        }
    }

    void relocate() {
        if(transform.position.y >= 11.6f) {
            Vector3 relocate = transform.position;
            relocate.y = -11f;
            transform.position = relocate;
        }
        else if(transform.position.x >= 19.6f) {
            Vector3 relocate = transform.position;
            relocate.x = -19.3f;
            transform.position = relocate;
        }
        else if(transform.position.x <= 19.3f) {
            Vector3 relocate = transform.position;
            relocate.x = 19.6f;
            transform.position = relocate;
        }
        else if(transform.position.y <= -10.6f) {
            Vector3 relocate = transform.position;
            relocate.y = 11f;
            transform.position = relocate;
        }
        // xValue = Random.Range(0, xValues.Length);
        // yValue = Random.Range(0, yValues.Length);
    }
}
