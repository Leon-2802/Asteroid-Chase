using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeismicHit : MonoBehaviour
{
    public SeismicChargeCtrl seismicCtrl;
    [SerializeField] private string explosion = null;
    MeteorPooler meteorPooler;
    [SerializeField] private GameObject hitSphere = null;
    [SerializeField] private GameObject sprite = null;
    private bool done = false;

    void Start() 
    {
        done = false;
        meteorPooler = MeteorPooler.Instance;
    }
    void OnEnable() 
    {
        done = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("target") || other.CompareTag("laser") || other.CompareTag("enemy") || other.CompareTag("enemyLaser")) {
            if(done == false) {
                done = true;
                hitSphere.SetActive(true);
                meteorPooler.SpawnProjectileFromPool(explosion, transform.position, transform.rotation);
                meteorPooler.ObjectDestroyed(explosion);
                sprite.SetActive(false);
                SoundManager.sManagerInstance.Audio.PlayOneShot(SoundManager.sManagerInstance.seismicCharge);
                seismicCtrl.noHit = false;
                seismicCtrl.currentLifetime = 0.1f;
            }
        }
    }
}
