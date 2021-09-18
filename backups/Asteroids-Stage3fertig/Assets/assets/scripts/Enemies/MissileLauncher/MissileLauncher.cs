using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : Enemy
{
    [SerializeField] private ShootAtTargetMissile shootAtTargetMissile = null;
    [SerializeField] private FlyTowardsMovement movement = null;
    [SerializeField] private shipController shipController;

    void Awake() {
        shipController = shipController.instance;
        meteorPooler = MeteorPooler.Instance;
        target = shipController.gameObject.transform;
    }
    void OnEnable() 
    {
        movement.target = target.position;
    }

    void Update() 
    {
        if(shootAtTargetMissile.shot == true) {
            shootAtTargetMissile.shot = false;
            movement.SetMoveInt();
            movement.target = target.position;
        }
    }
}
