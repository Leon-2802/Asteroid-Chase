using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMovement : MonoBehaviour
{
    [SerializeField] private StarDestroyerManager starDestroyerManager = null;
    [SerializeField] private int rowNumber = 0;
    [SerializeField] private GameObject[] children = null;
    [SerializeField] private WarshipMovement mothershipMovement = null;
    [SerializeField] private float anchor1 = 0f;
    [SerializeField] private float anchor2 = 0f;
    [SerializeField] private float axis = -31f;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float speedIncreaseCntdwn = 0f;
    private float currentAnchor = 0f;
    private float currentCntdwn = 0f;

    private void OnEnable() 
    {
        currentAnchor = anchor1;
        currentCntdwn = speedIncreaseCntdwn;
    }

    // Update is called once per frame
    void Update()
    {
        if(mothershipMovement.arrived)
        {
            currentCntdwn -= Time.deltaTime;
            if(currentAnchor > axis)
            {
                MovementPositive();
            }
            else if(currentAnchor < axis)
            {
                MovementNegative();
            }
        }

        if(currentCntdwn < 0) {
            speed++;
            currentCntdwn = speedIncreaseCntdwn;
        }

        for(int i = 0; i < children.Length; i++) {
            if(children[i].activeInHierarchy)
                return;
            starDestroyerManager.rowDestroyed[rowNumber] = true;
            this.gameObject.SetActive(false);
        }
    }

    void MovementPositive()
    {
        if(transform.position.x < currentAnchor) {
            Vector3 newPosition = transform.position;
            newPosition += transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }
        else {
            if(currentAnchor.Equals(anchor1)) {
                currentAnchor = anchor2;
            }
            else if(currentAnchor.Equals(anchor2)) {
                currentAnchor = anchor1;
            }
                
        }
    }
    void MovementNegative()
    {
        if(transform.position.x > currentAnchor) {
            Vector3 newPosition = transform.position;
            newPosition -= transform.right * speed * Time.deltaTime;
            transform.position = newPosition;
        }
        else {
            if(currentAnchor.Equals(anchor1)) {
                currentAnchor = anchor2;
            }
            else if(currentAnchor.Equals(anchor2)) {
                currentAnchor = anchor1;
            }
                
        }
    }
}
