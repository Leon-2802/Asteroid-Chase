using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 0f;
    [SerializeField] private Transform anchor = null;
    void Update()
    {
        transform.RotateAround(anchor.position, transform.forward, Time.deltaTime * spinSpeed);
    }
}
