using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsMovement : MonoBehaviour
{
    [SerializeField] private Enemy mainScript = null;
    // public bool canMove = false;
    public Vector3 target;
    private Vector3 moving;
    [SerializeField] private float speed = 0f;
    private float moveInt = 0.3f;
    private float currentMoveInt;

    void Start()
    {
        moving = new Vector3(0f, 0f, 0f);
        SetMoveInt();
    }
    void OnEnable() 
    {
        SetMoveInt();
    }

    void Update()
    {
        currentMoveInt -= Time.deltaTime;
        if(currentMoveInt <= 0) {
            if(Vector2.Distance(mainScript.enemyPos.position, mainScript.target.position) < 2f)
                return;
            else {
                Vector2 moving2d = Vector2.MoveTowards(mainScript.enemyPos.position, target, speed * Time.deltaTime);
                moving.x = moving2d.x;
                moving.y = moving2d.y;
                mainScript.enemyPos.position = moving;
            }
        }
    }
    public void SetMoveInt()
    {
        currentMoveInt = moveInt;
    }
}
