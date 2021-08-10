using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossMovement : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    public bool move = true;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float slowSpeed = 0f;
    private float currentSpeed;
    private float xValue;
    private float yValue;
    void OnEnable()
    {
        currentSpeed = speed;
        Relocate();
    }

    void Update()
    {
        if(move == false)
            currentSpeed = slowSpeed;
        else    
            currentSpeed = speed;
        
        Vector3 newPos = mainScript.enemyPos.position;
        newPos += new Vector3(xValue, yValue) * currentSpeed * Time.deltaTime;
        mainScript.enemyPos.position = newPos;

        if(mainScript.enemyPos.position.y >= 14.4f || mainScript.enemyPos.position.y <= -12f || mainScript.enemyPos.position.x >= 19.4f || mainScript.enemyPos.position.x <= -23f) 
            Relocate();
    }

    void Relocate()
    {
        if(mainScript.enemyPos.position.y > 0)
            yValue = UnityEngine.Random.Range(-1.2f, -0.7f);
        else
            yValue = UnityEngine.Random.Range(0.7f, 1.2f);

        if(mainScript.enemyPos.position.x > 0)
            xValue = UnityEngine.Random.Range(-1.2f, 0.7f);
        else
            xValue = UnityEngine.Random.Range(0.7f, 1.2f);
    }
}
