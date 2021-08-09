﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : Enemy
{
    public EnemyHitPrc enemyHitPrc;
    public ShootAtTargetMissile shootAtTargetMissile;
    public FlyTowardsMovement movement;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private float speed = 0f;

    private void Start() {
        meteorPooler = MeteorPooler.Instance;
        target = GameObject.FindWithTag("Player").transform;

        rotateTowards = this.gameObject.AddComponent<RotateTowards>();
        rotateTowards.mainScript = this;
        rotateTowards.pauseTime = pauseTimeAfterRotation;

        shootAtTargetMissile = this.gameObject.AddComponent<ShootAtTargetMissile>();
        shootAtTargetMissile.mainScript = this;
        shootAtTargetMissile.shootInt = shootIntervall;

        enemyHitPrc = this.gameObject.AddComponent<EnemyHitPrc>();
        enemyHitPrc.mainScript = this;
        enemyHitPrc.maxHealth = maxHealth;
        enemyHitPrc.explosion = explosion;

        movement = this.gameObject.AddComponent<FlyTowardsMovement>();
        movement.mainScript = this;
        movement.target = target.position;
        movement.speed = speed;
    }
    // void OnEnable() 
    // {
    // }

    void Update() 
    {
        if(shootAtTargetMissile.shot == true) {
            shootAtTargetMissile.shot = false;
            movement.SetMoveInt();
            movement.target = target.position;
        }
    }
}