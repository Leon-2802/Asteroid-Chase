using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ionenkanone : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlash = null;
    [SerializeField] private GameObject ionenstrahl = null;
    [SerializeField] private float counter = 0f;
    private float currentCounter = 0f;
    void OnEnable()
    {
        currentCounter = counter;
    }

    void Update()
    {
        currentCounter -= Time.deltaTime;
        if(currentCounter <= 1f) 
            muzzleFlash.SetActive(true);
    
        if(currentCounter <= 0) {
            ionenstrahl.SetActive(true);
            currentCounter = counter;
        }
    }
}
