using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitPrc : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject HitPrc = null;
    [SerializeField] private int giveHealth = 0;
    [SerializeField] private GameObject shield = null;
    [SerializeField] private GameObject swarm = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "health":
                HitPrc.GetComponent<spaceShipHitPrc>().GiveHealth(giveHealth);
                anim.SetTrigger("Heal");
                break;
            case "shieldCard":
                shield.SetActive(true);
                HitPrc.SetActive(false);
                break;
            case "swarmCard":
                swarm.SetActive(true);
                break;
        }
    }
}
