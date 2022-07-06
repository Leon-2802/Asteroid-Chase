using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayerAnims : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private spaceShipHitPrc spaceShipHitPrc = null;
    public void EndPlayerAnim(string message)
    {
        switch(message)
        {
            case "heal":
                anim.SetTrigger("NoHeal");
                break;
            case "hit":
                anim.SetTrigger("NoHit");
                spaceShipHitPrc.hit = false;
                break;
        }
    }
}
