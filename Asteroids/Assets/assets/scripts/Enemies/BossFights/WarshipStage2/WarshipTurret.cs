using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarshipTurret : Fighter
{
    [SerializeField] private ShootAtTargetTwice shootAtTargetTwice = null;
    void Update()
    {
        if(shootAtTargetTwice.shot == true) {
            shootAtTargetTwice.shootInt = UnityEngine.Random.Range(1, 4);
            shootAtTargetTwice.shot = false;
        }
    }
}
