using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwarmRotation : SwarmRotation
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform anchor = null;
    [SerializeField] private float spinSpeed = 0f;
    protected override void Update()
    {
        if(mainScript.target == player)
        {
            transform.RotateAround(anchor.position, transform.forward, Time.deltaTime * spinSpeed);
        }
        else
        {
            Vector2 lookdir = mainScript.target.position - transform.position;
            float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
            mainScript.enemyRb.rotation = angle;
        }
    }
}
