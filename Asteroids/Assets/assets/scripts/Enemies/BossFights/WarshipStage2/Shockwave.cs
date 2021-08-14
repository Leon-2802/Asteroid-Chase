using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField] private GameObject shockwaveCollider = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private float shockInt = 0f;
    [SerializeField] private float shockTime = 0f;
    private float currentShockInt;
    private float currentShockTime;
    void Start()
    {
        currentShockInt = 2f;
        currentShockTime = shockTime;
    }

    void Update()
    {
        currentShockInt -= Time.deltaTime;
        animator.SetBool("Shockwave", false);
        if(currentShockInt <= 0) {
            animator.SetBool("Shockwave", true);
            shockwaveCollider.SetActive(true);
            currentShockTime -= Time.deltaTime;
            if(currentShockTime <= 0) {
                shockwaveCollider.SetActive(false);
                currentShockTime = shockTime;
                currentShockInt = shockInt;
            }
        }
    }
}
