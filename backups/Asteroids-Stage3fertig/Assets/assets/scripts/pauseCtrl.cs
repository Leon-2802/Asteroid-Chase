using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseCtrl : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen = null;
    [SerializeField] private AudioSource music = null;
    [SerializeField] private Image pauseButton = null;
    [SerializeField] private Sprite pauseImage = null;
    [SerializeField] private Sprite playImage = null;
    private bool pause = false;
    void Update()
    {
        if(Input.GetButtonDown("Jump") && pause == false) 
            Pause();
        else if(Input.GetButtonDown("Jump") && pause == true) 
            Play();
    }
    public void ButtonPressed()
    {
        if(pause == false)
            Pause();
        else
            Play();
    }

    void Pause()
    {
        pause = true;
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        music.volume = 0.2f;
        pauseButton.sprite = playImage;
    }
    void Play()
    {
        pause = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        music.volume = 0.6f;
        pauseButton.sprite = pauseImage;
    }
}
