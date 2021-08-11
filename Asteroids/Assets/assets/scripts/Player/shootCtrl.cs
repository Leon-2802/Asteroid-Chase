using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shootCtrl : MonoBehaviour
{
    MeteorPooler meteorPooler;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private FixedJoystick joystickR = null;
    [SerializeField] private string laser = null;
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private Transform firePointL = null;
    [SerializeField] private Transform firePointR = null;
    [SerializeField] private string seismicCharge = null;
    [SerializeField] private Transform seismicFirePoint = null;
    private float recharge = 0.4f;
    private bool canShoot = true;

    [SerializeField] private int seismicCount = 0;
    [SerializeField] private TMP_Text seismicLeft = null;
    private float seismicRecharge = 5f;
    private bool canLaunch = true;

    private void Start() {
        meteorPooler = MeteorPooler.Instance;
    }
    void Update()
    {
        // if(Input.GetButton("Fire1") && canShoot == true) {
        //     recharge = 0.4f;
        //     canShoot = false;
        //     meteorPooler.SpawnProjectileFromPool(laser, firePointL.position, firePointL.rotation);
        // }

        float x = joystickR.Horizontal;
        float y = joystickR.Vertical;
        if(x >= 0.1 || x <= -0.1 || y >= 0.1 || y <= -0.1) {
            if(canShoot == true) {
                Shoot();
            }
        }
        if(canShoot == false) {
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

    private void Shoot()
    {
        recharge = 0.4f;
        canShoot = false;
        if(gameManager.currentStage == GameManager.Stages.STAGE_1)
            meteorPooler.SpawnProjectileFromPool(laser, firePoint.position, firePoint.rotation);

        else {
            meteorPooler.SpawnProjectileFromPool(laser, firePointL.position, firePointL.rotation);
            meteorPooler.SpawnProjectileFromPool(laser, firePointR.position, firePointR.rotation);
        }
    }

    public void launchCharge() 
    {
         if(seismicCount > 0 && canLaunch == true) {
            seismicRecharge = 5f;
            canLaunch = false;
            meteorPooler.SpawnProjectileFromPool(seismicCharge, seismicFirePoint.position, seismicFirePoint.rotation);
            seismicCount--;
            seismicLeft.text = seismicCount.ToString() + "x";
        }
    }
}
