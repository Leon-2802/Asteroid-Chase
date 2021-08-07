using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsMovement : MonoBehaviour
{
    public Enemy mainScript;
    public bool canMove = false;
    public Vector3 target;
    private Vector3 moving;
    public float speed = 0f;
    private float moveInt = 0.3f;
    private float currentMoveInt;

    void Start()
    {
        moving = new Vector3(0f, 0f, 0f);
        canMove = false;
        SetMoveInt();
    }
    void OnEnable() 
    {
        canMove = false;
        SetMoveInt();
    }

    void Update()
    {
        if(canMove == true) {
            currentMoveInt -= Time.deltaTime;
            if(currentMoveInt <= 0) {
                if(Vector2.Distance(mainScript.target.position, mainScript.enemyPos.position) < 2f)
                    canMove = false;
                else {
                    Vector2 moving2d = Vector2.MoveTowards(mainScript.enemyPos.position, target, speed * Time.deltaTime);
                    moving.x = moving2d.x;
                    moving.y = moving2d.y;
                    mainScript.enemyPos.position = moving;
                }
            }
        }
    }
    public void SetMoveInt()
    {
        currentMoveInt = moveInt;
    }
}
