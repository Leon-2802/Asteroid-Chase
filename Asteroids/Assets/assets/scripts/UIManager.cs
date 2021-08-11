using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private TMP_Text stageInfo = null;
    [SerializeField] private TMP_Text bossFight1 = null;
    [SerializeField] private float showUI = 0f;
    private float currentCounter;
    private bool hide2 = false;

    void Start()
    {
        currentCounter = showUI;
    }


    void Update()
    {
        StageInfo();
        BossFightUI();
    }

    void StageInfo()
    {
        switch(gameManager.currentStage) 
        {
            case GameManager.Stages.STAGE_2:
                if(hide2 == false) {
                    stageInfo.text = "- Stage 1 cleared -";
                    stageInfo.gameObject.SetActive(true);
                    currentCounter -= Time.deltaTime;
                    if(currentCounter <= 0) {
                        stageInfo.gameObject.SetActive(false);
                        hide2 = true;
                        currentCounter = showUI;
                    }
                }
                break;
        }
    }
    void BossFightUI()
    {
        if(gameManager.scoreCounter >= gameManager.bossFightStarts[0] && gameManager.bossDefeated[0] == false) 
            bossFight1.gameObject.SetActive(true);
        else
            bossFight1.gameObject.SetActive(false);
    }
}
