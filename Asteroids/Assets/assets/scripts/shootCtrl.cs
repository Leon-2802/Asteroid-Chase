using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootCtrl : MonoBehaviour
{
    MeteorPooler meteorPooler;
    [SerializeField] private string laser = null;
    [SerializeField] private Transform firePointL = null;
    [SerializeField] private string seismicCharge = null;
    [SerializeField] private Transform seismicFirePoint = null;
    private Touch touch;

    private float recharge = 0.4f;
    private bool canShoot = true;

    [SerializeField] private int seismicCount = 0;
    private float seismicRecharge = 5f;
    private bool canLaunch = true;

    private void Start() {
        meteorPooler = MeteorPooler.Instance;
    }
    void Update()
    {
        if(Input.GetButton("Fire1") && canShoot == true) {
            recharge = 0.4f;
            canShoot = false;
            meteorPooler.SpawnProjectileFromPool(laser, firePointL.position, firePointL.rotation);
        }

        // if(Input.touchCount > 0 && canShoot == true) {
        //     foreach (Touch touch in Input.touches) {
        //         if(touch.phase == TouchPhase.Began && touch.position.x > Screen.width) {
        //             recharge = 0.4f;
        //             canShoot = false;
        //             Instantiate(laser, firePointL.position, firePointL.rotation);
        //         }
        //     }
        // }

        else if(canShoot == false) {
            recharge -= Time.deltaTime;
            if(recharge <= 0) {
                canShoot = true;
            }
        }
        
        if(canLaunch == false) {
            seismicRecharge -= Time.deltaTime;
            if(seismicRecharge <= 0)
                canLaunch = true;
        }
    }

    public void launchCharge() 
    {
         if(seismicCount > 0 && canLaunch == true) {
            seismicRecharge = 5f;
            canLaunch = false;
            meteorPooler.SpawnProjectileFromPool(seismicCharge, seismicFirePoint.position, seismicFirePoint.rotation);
            seismicCount--;
        }
    }
}
