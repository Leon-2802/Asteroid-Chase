﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private TMP_Text stageInfo = null;
    [SerializeField] private TMP_Text bossFight1 = null;
    [SerializeField] private GameObject healthbarBoss = null;
    [SerializeField] private GameObject bossFight2 = null;
    [SerializeField] private GameObject bossFight3 = null;
    [SerializeField] private float showUI = 0f;
    private float currentCounter;
    private bool hide2 = false;
    private bool hide3 = false;

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
            case GameManager.Stages.STAGE_3:
                if(hide3 == false) {
                    stageInfo.text = "- Stage 2 cleared -";
                    stageInfo.gameObject.SetActive(true);
                    currentCounter -= Time.deltaTime;
                    if(currentCounter <= 0) {
                        stageInfo.gameObject.SetActive(false);
                        hide3 = true;
                        currentCounter = showUI;
                    }
                }
                break;
            case GameManager.Stages.STAGE_4:
                if(hide3 == false) {
                    stageInfo.text = "- Stage 3 cleared -";
                    stageInfo.gameObject.SetActive(true);
                    currentCounter -= Time.deltaTime;
                    if(currentCounter <= 0) {
                        stageInfo.gameObject.SetActive(false);
                        hide3 = true;
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

        if(gameManager.scoreCounter >= gameManager.bossFightStarts[1] && gameManager.bossDefeated[1] == false) {
            healthbarBoss.SetActive(true);
            bossFight2.SetActive(true);
        }
        else if(gameManager.bossDefeated[1] == true && gameManager.scoreCounter < gameManager.bossFightStarts[2]) {
            healthbarBoss.SetActive(false);
            bossFight2.SetActive(false);
        }

        if(gameManager.scoreCounter >= gameManager.bossFightStarts[2] && gameManager.bossDefeated[2] == false) {
            bossFight3.SetActive(true);
            healthbarBoss.SetActive(true);
        }
        else if(gameManager.bossDefeated[2] == true && gameManager.scoreCounter < gameManager.bossFightStarts[3]) {
            healthbarBoss.SetActive(false);
            bossFight3.SetActive(false);
        }
        
    }
}
