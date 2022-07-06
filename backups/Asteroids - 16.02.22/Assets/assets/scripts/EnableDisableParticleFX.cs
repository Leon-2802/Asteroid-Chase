using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableParticleFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleEffect = null;
    void OnEnable() 
    {
        particleEffect.Play();
    }

    void OnDisable()
    {
        particleEffect.Clear();
    } 
}
