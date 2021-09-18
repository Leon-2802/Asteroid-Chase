using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    [SerializeField] private SwarmRotation rotation = null;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float stopInt = 0f;
    private float currentStopCounter;
    Vector3 movement = new Vector3(0, 0, 0);
    void OnEnable()
    {
        currentStopCounter = stopInt;
    }

    void Update()
    {
        currentStopCounter -= Time.deltaTime;
        if(currentStopCounter <= 0)
        {
            rotation.enabled = false;
            Kamikaze();        
        }
    }

    void Kamikaze()
    {
        movement = mainScript.enemyPos.position;
        movement += transform.right * speed * Time.deltaTime;
        mainScript.enemyPos.position = movement;
    }
}
