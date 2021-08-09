using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    void Start() {
        meteorPooler = MeteorPooler.Instance;
    }
    
    void OnEnable()
    {
        distanceChecker = this.gameObject.AddComponent<DistanceChecker>();
        distanceChecker.mainScript = this;
        rotateTowards = this.gameObject.AddComponent<RotateTowards>();
        rotateTowards.mainScript = this;
        rotateTowards.pauseTime = pauseTimeAfterRotation;
        shootAtTarget = this.gameObject.AddComponent<ShootAtTarget>();
        shootAtTarget.mainScript = this;
    }
}
