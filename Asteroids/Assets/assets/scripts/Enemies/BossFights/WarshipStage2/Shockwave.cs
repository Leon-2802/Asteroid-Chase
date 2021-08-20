using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField] private LaunchEnergyBalls launchEnergyBalls = null;
    [SerializeField] private float shockInt = 0f;
    [SerializeField] private GameObject shockwaveCollider = null;
    [SerializeField] private Animator animator = null;
    private float currentShockInt;
    void Start()
    {
        currentShockInt = 2f;
    }

    void Update()
    {
        currentShockInt -= Time.deltaTime;
        if(currentShockInt <= 0) {
            launchEnergyBalls.SpawnEnergyBalls();
            currentShockInt = shockInt;
        }
    }
}
