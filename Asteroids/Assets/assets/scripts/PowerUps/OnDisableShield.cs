using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableShield : MonoBehaviour
{
    [SerializeField] private spaceShipHitPrc spaceShipHitPrc = null;
    private void OnDisable() 
    {
        spaceShipHitPrc.enabled = true;
    }
}
