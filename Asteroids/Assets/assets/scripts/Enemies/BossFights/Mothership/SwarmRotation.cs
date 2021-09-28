using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmRotation : MonoBehaviour
{
    [SerializeField] protected Enemy mainScript = null;
    protected virtual void Update()
    {
        Vector2 lookdir = mainScript.target.position - transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
        mainScript.enemyRb.rotation = angle;
    }
}
