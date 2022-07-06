using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableShield : MonoBehaviour
{
    [SerializeField] private GameObject HitPrc = null;
    private void OnDisable() 
    {
        HitPrc.SetActive(true);
    }
}
