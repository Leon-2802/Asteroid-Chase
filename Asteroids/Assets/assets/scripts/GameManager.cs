using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private TMP_Text score = null;
    [SerializeField] private TMP_Text timer = null;
    private int scoreCounter = 0;
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
    }

    public void AsteroidDied(int points) {
        scoreCounter += points;
        score.text = scoreCounter.ToString();
    }
}
