using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    [SerializeField] private float countdown = 0f;
    private float currentCoutndown;

    void OnEnable() 
    {
        currentCoutndown = countdown;
    }
    void Update()
    {
        currentCoutndown -= Time.deltaTime;
        if(currentCoutndown <= 0)
            this.gameObject.SetActive(false);
    }
}
