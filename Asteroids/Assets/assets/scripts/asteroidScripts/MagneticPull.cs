using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPull : MonoBehaviour
{
    shipController shipController;
    meteorManager meteorManager;
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject hitSphere = null;

    void Start()
    {
        meteorManager = meteorManager.instance;
        shipController = shipController.instance;
    }

    void Update()
    {
        if(transform.position.y >= 11.6f || transform.position.y <= -11.6f || transform.position.x >= 19.3f || transform.position.x <= -19.3f) {
            hitSphere.SetActive(false);
        }
        else
            hitSphere.SetActive(true);

        if(meteorManager.magneticPull == true) {
            animator.SetBool("PullActive", true);
            shipController.MoveTowardsMagnetic(this.gameObject.transform.position);
        }
        else 
            animator.SetBool("PullActive", false);
    }
}
