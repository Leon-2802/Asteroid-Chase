﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    //Stages:
    public enum Stages
    {
        STAGE_1, STAGE_2, STAGE_3, STAGE_4, STAGE_5
    }
    public Stages currentStage;

    //BossFights:
    [SerializeField] private BossManger bossManger = null;
    public int[] bossFightStarts;
    public bool[] bossFight;
    public int[] deadBossEnemies;
    public bool[] bossDefeated;

    //Score
    public int scoreCounter = 0;
    [SerializeField] private TMP_Text score = null;

    //Timer:
    [SerializeField] private TMP_Text timer = null;
    private float timerFloat = 0;
    private int minuteCounter = 0; 

    private void Awake() 
    {
        if(instance != null) {
            Debug.Log("Second Gamemanager found");
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
        
        StageManaging(Stages.STAGE_1);
    }

    private void Update() {
        timerFloat += Time.deltaTime;
        if(timerFloat <= 9) {
            timer.text = minuteCounter.ToString() + ":0" + timerFloat.ToString("0");
        }
        else if(timerFloat >= 10 && timerFloat <= 59) {
            timer.text = minuteCounter.ToString() + ":" + timerFloat.ToString("0");
        }
        else if(timerFloat >= 59) {
            minuteCounter++;
            timerFloat = 0;
        }

        if(scoreCounter >= bossFightStarts[0] && scoreCounter < bossFightStarts[1]) {
            if(bossDefeated[0] == true) {
                bossFight[0] = false;
                return;
            }
            else
                bossFight[0] = true;

            if(deadBossEnemies[0] >= 3) {
                bossDefeated[0] = true;
                StageManaging(Stages.STAGE_2);
            }
        }
        if(scoreCounter >= bossFightStarts[1] && scoreCounter < bossFightStarts[2]) {
            if(bossDefeated[1] == true) {
                bossFight[1] = false;
                StageManaging(Stages.STAGE_3);
            }
            else {
                bossFight[1] = true;
                bossManger.StartBossFight2();
            }
        }
        if(scoreCounter >= bossFightStarts[2] && scoreCounter < bossFightStarts[3]) {
            if(bossDefeated[2] == true) {
                bossFight[2] = false;
                StageManaging(Stages.STAGE_4);
            }
            else {
                bossFight[2] = true;
                bossManger.StartBossFight3();
            }
        }
        if(scoreCounter >= bossFightStarts[3] && scoreCounter < bossFightStarts[4]) {
            if(bossDefeated[3] == true) {
                bossFight[3] = false;
                StageManaging(Stages.STAGE_5);
            }
            else {
                bossFight[3] = true;
                bossManger.StartBossFight4();
            }
        }
    }

    public void GivePoints(int points) {
        scoreCounter += points;
        score.text = scoreCounter.ToString();
    }

    private void StageManaging(Stages stages)
    {
        currentStage = stages;
    }
}
