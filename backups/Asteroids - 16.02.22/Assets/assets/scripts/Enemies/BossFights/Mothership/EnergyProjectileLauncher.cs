using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private float shootInt = 0f;
    private float currentShootInt;
    void OnEnable()
    {
        currentShootInt = shootInt;
    }

    void Update()
    {
        currentShootInt -= Time.deltaTime;
        if(currentShootInt <= 0) {
            projectile.transform.position = this.transform.position;
            projectile.transform.rotation = this.transform.rotation;
            projectile.SetActive(true);
            currentShootInt = shootInt;
        }
    }
}
