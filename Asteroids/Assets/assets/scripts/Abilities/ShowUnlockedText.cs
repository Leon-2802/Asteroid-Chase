using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnlockedText : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private GameObject text = null;
    void OnEnable() 
    {
        if(gameManager.currentStage != GameManager.Stages.STAGE_1)
            text.SetActive(true);
    }
}
