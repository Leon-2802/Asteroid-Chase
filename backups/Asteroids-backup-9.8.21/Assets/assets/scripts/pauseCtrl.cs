using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseCtrl : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen = null;
    private bool pause = false;
    void Update()
    {
        if(Input.GetButtonDown("Jump") && pause == false) {
            pause = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else if(Input.GetButtonDown("Jump") && pause == true) {
            pause = false;
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }
}
