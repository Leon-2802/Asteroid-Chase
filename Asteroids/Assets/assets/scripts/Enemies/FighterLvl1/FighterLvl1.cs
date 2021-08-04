using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterLvl1 : Enemy
{
    public int health;
    public EnemyHitPrc enemyHitPrc;
    void Start() 
    {
        meteorPooler = MeteorPooler.Instance;
        target = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable() 
    {
        rotateTowards = this.gameObject.AddComponent<RotateTowards>();
        rotateTowards.mainScript = this;
        shootAtTarget = this.gameObject.AddComponent<ShootAtTarget>();
        shootAtTarget.mainScript = this;
        enemyHitPrc = this.gameObject.AddComponent<EnemyHitPrc>();
        enemyHitPrc.mainScript = this;
    }
}
