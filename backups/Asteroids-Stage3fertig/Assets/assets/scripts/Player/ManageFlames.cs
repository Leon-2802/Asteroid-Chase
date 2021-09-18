using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFlames : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb = null;
    [SerializeField] private ParticleSystem emmissionRight = null;
    [SerializeField] private ParticleSystem emmissionLeft = null;
    [SerializeField] private float startLifetimeFlying = 1.3f;
    [SerializeField] private float startLifetimeStanding = 0.3f;
    private Vector2 zero = new Vector2(0, 0);

    void Update()
    {
        if(playerRb.velocity != zero) {
            emmissionRight.startLifetime = startLifetimeFlying;
            emmissionLeft.startLifetime = startLifetimeFlying;
        }
        else {
            emmissionRight.startLifetime = startLifetimeStanding;
            emmissionLeft.startLifetime = startLifetimeStanding;
        }
    }
}
