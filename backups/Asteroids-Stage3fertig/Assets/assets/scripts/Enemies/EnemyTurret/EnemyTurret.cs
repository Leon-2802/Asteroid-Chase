using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private Sprite baseNormal = null;
    [SerializeField] private Sprite baseShooting = null;
    void Start() 
    {
        meteorPooler = MeteorPooler.Instance;
    }

    void Update() 
    {
        if(inRange == false) {
            spriteRenderer.sprite = baseNormal;
        }
        else {
            spriteRenderer.sprite = baseShooting;
        }
    }
}
