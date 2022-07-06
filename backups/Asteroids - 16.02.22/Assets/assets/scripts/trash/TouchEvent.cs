using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    [SerializeField] public GameObject lenkraketeParent = null;
    [SerializeField] public GameObject lenkrakete = null;
    [SerializeField] private Animator animator = null;

    private void OnMouseUpAsButton() 
    {
        SetAsTarget();
    }

    public void SetAsTarget() 
    {
        if(!lenkraketeParent.activeInHierarchy) 
            return;
        if(lenkraketeParent.GetComponent<LenkraketeManager>().missileCounter < 1)
            return;
        animator.SetBool("Selected", true);
        lenkrakete.GetComponent<FollowTarget>().target = this.transform;
        lenkrakete.SetActive(true);
    }
}
