using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHitPrc : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private spaceShipHitPrc spaceShipHitPrc = null;
    [SerializeField] private int giveHealth = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "health":
                spaceShipHitPrc.GiveHealth(giveHealth);
                anim.SetTrigger("Heal");
                break;
        }
    }
}
