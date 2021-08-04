using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    void Start() {
        meteorPooler = MeteorPooler.Instance;
        target = GameObject.FindWithTag("Player").transform;
    }
    
    void OnEnable()
    {
        distanceChecker = this.gameObject.AddComponent<DistanceChecker>();
        distanceChecker.mainScript = this;
        rotateTowards = this.gameObject.AddComponent<RotateTowards>();
        rotateTowards.mainScript = this;
        shootAtTarget = this.gameObject.AddComponent<ShootAtTarget>();
        shootAtTarget.mainScript = this;
    }
}
