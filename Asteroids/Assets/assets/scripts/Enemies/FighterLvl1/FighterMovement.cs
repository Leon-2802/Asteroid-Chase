using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float moveInt = 0f;
    private int anchorsIndex;
    private float currentMoveInt;

    void OnEnable() 
    {
        currentMoveInt = 0.5f;
        anchorsIndex = 1;
    }
    void Update()
    {
        currentMoveInt -= Time.deltaTime; 
        if(currentMoveInt <= 0) 
        {
            if(anchorsIndex == 1) 
            {
                Vector3 newPosition = mainScript.enemyPos.position;
                newPosition += transform.right * speed * Time.deltaTime;
                mainScript.enemyPos.position = newPosition;
                if(transform.position.x >= 15)
                    MovementEnded();
            }
            else if(anchorsIndex == 2) 
            {
                Vector3 newPosition = mainScript.enemyPos.position;
                newPosition -= transform.up * speed * Time.deltaTime;
                mainScript.enemyPos.position = newPosition;
                if(transform.position.y <= -8)
                    MovementEnded();
            }
            else if(anchorsIndex == 3) 
            {
                Vector3 newPosition = mainScript.enemyPos.position;
                newPosition -= transform.right * speed * Time.deltaTime;
                mainScript.enemyPos.position = newPosition;
                if(transform.position.x <= -16)
                    MovementEnded();
            }
            else if(anchorsIndex == 4) 
            {
                Vector3 newPosition = mainScript.enemyPos.position;
                newPosition += transform.up * speed * Time.deltaTime;
                mainScript.enemyPos.position = newPosition;
                if(transform.position.y >= 7)
                    MovementEnded();
            }
        }
    }

    void MovementEnded()
    {
        currentMoveInt = moveInt;
        if(anchorsIndex < 4) 
            anchorsIndex++;
        else 
            anchorsIndex = 1;
    }
}
