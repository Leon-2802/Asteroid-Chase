using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private float rotateAmount = 0f;
    
    void Update()
    {
        rb.rotation = rotateAmount;
    }
}
