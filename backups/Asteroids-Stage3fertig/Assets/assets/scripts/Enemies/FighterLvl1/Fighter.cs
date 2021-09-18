using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Enemy
{
    [SerializeField] private shipController shipController;
    void Start() 
    {
        shipController = shipController.instance;
        meteorPooler = MeteorPooler.Instance;
        target = shipController.gameObject.transform;
    }
}
