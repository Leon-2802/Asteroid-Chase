using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeismicHit : MonoBehaviour
{
    public SeismicChargeCtrl seismicCtrl;
    // [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject hitSphere = null;
    [SerializeField] private GameObject sprite = null;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("target") || other.CompareTag("smolTarget")) {
            hitSphere.SetActive(true);
            sprite.SetActive(false);
            SoundManager.sManagerInstance.Audio.PlayOneShot(SoundManager.sManagerInstance.seismicCharge);
            seismicCtrl.noHit = false;
            seismicCtrl.currentLifetime = 0.1f;
        }
    }
}
