using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnims : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    public void EndAnim(string message)
    {
        switch(message)
        {
            case "hit":
                anim.SetTrigger("NoHit");
                break;
            case "deselect":
                anim.SetBool("Selected", false);
                break;
        }
    }
}
