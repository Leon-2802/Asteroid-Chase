using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LenkraketeManager : MonoBehaviour
{
    [SerializeField] public int missileCounter = 3;
    [SerializeField] private GameObject lenkrakete = null;
    [SerializeField] private TMP_Text missileCounterUI = null;
    [SerializeField] private Image lenkraketeUI = null;
    [SerializeField] private Sprite activeUI = null;
    [SerializeField] private Sprite inactive = null;
    [SerializeField] private GameObject infoText = null;

    private void OnEnable() 
    {
        if(missileCounter > 0) {
            lenkraketeUI.sprite = activeUI;
            infoText.SetActive(true);
        }
    }

    private void OnDisable() 
    {
        missileCounter--;
        missileCounterUI.text = missileCounter.ToString() + "x";
        lenkraketeUI.sprite = inactive;
        lenkrakete.SetActive(false);
    }
}
