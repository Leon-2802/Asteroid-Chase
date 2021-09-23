using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private Image laserUI = null;
    [SerializeField] private Sprite laserDouble = null;
    [SerializeField] private GameObject laserDoubleText = null;
    private bool laserTextActive = false;
    [SerializeField] private GameObject seismicCharge = null;
    // [SerializeField] private GameObject lenkrakete = null;
    // [SerializeField] private GameObject laserBurst = null;
    // [SerializeField] private GameObject hacking = null;

    void Update()
    {
        switch(gameManager.currentStage)
        {
            case GameManager.Stages.STAGE_2:
                laserUI.sprite = laserDouble;
                if(laserTextActive == false) {
                    laserDoubleText.SetActive(true);
                    laserTextActive = true;
                }
                break;
            case GameManager.Stages.STAGE_3:
                seismicCharge.SetActive(true);
                break;
            // case GameManager.Stages.STAGE_4:
            //     lenkrakete.SetActive(true);
            //     break;
            // case GameManager.Stages.STAGE_5:
            //     laserBurst.SetActive(true);
            //     break;
        }

        // if(gameManager.bossDefeated[4] == true)
        //     hacking.SetActive(true);
    }
}
