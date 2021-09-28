using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EruptionLauncher : MonoBehaviour
{
    [SerializeField] private GameObject warning = null;
    [SerializeField] private GameObject eruption = null;
    [SerializeField] private float intervallMin = 0f;
    [SerializeField] private float intervallMax = 0f;
    [SerializeField] private float intAfterWarning = 2f;
    private float currentIntAfterWarning;
    private float currentIntervall;

    void OnEnable()
    {
        currentIntervall = UnityEngine.Random.Range(intervallMin, intervallMax);
        currentIntAfterWarning = intAfterWarning;
    }

    // Update is called once per frame
    void Update()
    {
        currentIntervall -= Time.deltaTime;
        if(currentIntervall <= 0)
        {
            warning.SetActive(true);
            currentIntAfterWarning -= Time.deltaTime;
            if(currentIntAfterWarning <= 0) {
                warning.SetActive(false);
                eruption.SetActive(true);
                eruption.transform.position = new Vector3(eruption.transform.position.x, warning.transform.position.y, 0);
                currentIntAfterWarning = intAfterWarning;
                currentIntervall = UnityEngine.Random.Range(intervallMin, intervallMax);
            }
        }
    }
}
