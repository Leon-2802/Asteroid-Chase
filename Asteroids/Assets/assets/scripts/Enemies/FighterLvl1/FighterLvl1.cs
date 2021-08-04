using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterLvl1 : Enemy
{
    public EnemyHitPrc enemyHitPrc;
    [SerializeField] private int maxHealth = 0;
    public FighterMovement fighterMovement;
    //Speziell für FighterLvl1-Movement:
    [SerializeField] private float speed = 0f;
    [SerializeField] private float moveInt = 0f;

    void OnEnable() 
    {
        meteorPooler = MeteorPooler.Instance;
        target = GameObject.FindWithTag("Player").transform;
        rotateTowards = this.gameObject.AddComponent<RotateTowards>();
        rotateTowards.mainScript = this;
        shootAtTarget = this.gameObject.AddComponent<ShootAtTarget>();
        shootAtTarget.mainScript = this;
        enemyHitPrc = this.gameObject.AddComponent<EnemyHitPrc>();
        enemyHitPrc.mainScript = this;
        enemyHitPrc.maxHealth = maxHealth;
        fighterMovement = this.gameObject.AddComponent<FighterMovement>();
        fighterMovement.mainScript = this;
        fighterMovement.speed = speed;
        fighterMovement.moveInt = moveInt;
    }
}
